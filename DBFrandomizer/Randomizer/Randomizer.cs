using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DBFrandomizer.Tool;
using DBFrandomizer.Logic;
using DBFrandomizer.Common;
using DBFrandomizer.Formats;

namespace DBFrandomizer.Randomizer
{
    public class Randomizer
    {
        public List<uint> Body;

        public List<uint> Face;

        public List<uint> Hair;

        public List<uint> Head;

        public List<uint> Item;

        public List<uint> Leg;

        public string DirectoryPath;

        public string OutputPath;

        private RandomNumber Seed = new RandomNumber();

        public Randomizer(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        private List<uint> GetListIdFromFile(string filename)
        {
            // Read file and return list ID

            List<uint> ids = new List<uint>();

            using (BinaryDataReader reader = new BinaryDataReader(new FileStream(filename, FileMode.Open)))
            {
                int itemCount = (int)reader.Length / 0x1C;

                for (int i = 0; i < itemCount; i++)
                {
                    ids.Add(reader.ReadValue<uint>());
                    reader.Skip(0x18);
                }
            }

            // Remove empty id
            return ids.Where(x => x != 0xFFFFFFFF & x != 0x0).ToList();
        }

        private DBFlogic.RGB RandomRGB()
        {
            DBFlogic.RGB rgb = new DBFlogic.RGB();

            rgb.R = Seed.Next(256);
            rgb.G = Seed.Next(256);
            rgb.B = Seed.Next(256);

            return rgb;
        }

        public void Open()
        {
            Body = GetListIdFromFile(DirectoryPath + "/chara/param/part_body.bin");
            Face = GetListIdFromFile(DirectoryPath + "/chara/param/part_face.bin");
            Hair = GetListIdFromFile(DirectoryPath + "/chara/param/part_hair.bin");
            Head = GetListIdFromFile(DirectoryPath + "/chara/param/part_head.bin");
            Leg = GetListIdFromFile(DirectoryPath + "/chara/param/part_leg.bin");
        }

        public void RandomizeConfigureJarc(Dictionary<string, bool> setting)
        {
            jARC ConfigureJarc = new jARC(new FileStream(DirectoryPath + "/chara/param/configure.jarc", FileMode.Open));

            // Browse all files  
            foreach (KeyValuePair<string, SubMemoryStream> file in ConfigureJarc.Directory.Files)
            {
                // Reads the file if the file has never been read
                if (file.Value.ByteContent == null)
                {
                    file.Value.Read();
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (BinaryDataWriter configureWriter = new BinaryDataWriter(memoryStream))
                    {
                        using (BinaryDataReader configureReader = new BinaryDataReader(file.Value.ByteContent))
                        {
                            var configure = configureReader.ReadStruct<DBFlogic.Configure>();

                            // Randomize apparence
                            configure.TopID = setting["topCheckBox"] ? Body[Seed.Next(0, Body.Count)] : configure.TopID;
                            configure.HairID = setting["hairCheckBox"] ? Hair[Seed.Next(0, Hair.Count)] : configure.HairID;
                            configure.FaceID = setting["faceCheckBox"] ? Face[Seed.Next(0, Face.Count)] : configure.FaceID;
                            configure.BottomID = setting["bottomCheckBox"] ? Leg[Seed.Next(0, Leg.Count)] : configure.BottomID;
                            configure.BodyID = setting["bodyCheckBox"] ? Seed.Next(0, 22) : configure.BodyID;
                            configure.FaceFormID = setting["faceFormCheckBox"] ? Head[Seed.Next(0, Head.Count)] : configure.FaceFormID;

                            // Randomize color
                            configure.Top1Color = setting["topColorCheckBox"] ? RandomRGB() : configure.Top1Color;
                            configure.Top2Color = setting["topColorCheckBox"] ? RandomRGB() : configure.Top2Color;
                            configure.Hair1Color = setting["hairColorCheckBox"] ? RandomRGB() : configure.Hair1Color;
                            configure.Hair2Color = setting["hairColorCheckBox"] ? RandomRGB() : configure.Hair2Color;
                            configure.SkinColor = setting["skinColorCheckBox"] ? RandomRGB() : configure.SkinColor;
                            configure.Bottom1Color = setting["bottomColorCheckBox"] ? RandomRGB() : configure.Bottom1Color;
                            configure.Bottom2Color = setting["bottomColorCheckBox"] ? RandomRGB() : configure.Bottom2Color;
                            configure.Boots1Color = setting["bootsColorCheckBox"] ? RandomRGB() : configure.Boots1Color;
                            configure.Boots2Color = setting["bootsColorCheckBox"] ? RandomRGB() : configure.Boots2Color;
                            configure.EyesColor = setting["eyesColorCheckBox"] ? RandomRGB() : configure.EyesColor;
                            configure.GlovesColor = setting["glovesColorCheckBox"] ? RandomRGB() : configure.GlovesColor;
                            configure.TailColor = setting["tailColorCheckBox"] ? RandomRGB() : configure.TailColor;
                            configure.AuraColor = setting["auraColorCheckBox"] ? RandomRGB() : configure.AuraColor;

                            // Randomize Miscellaneous
                            configure.HasTail = setting["tailMiscellaneousCheckBox"] ? (byte)Seed.Next(0, 2) : configure.HasTail;
                            configure.Gender = setting["genderMiscellaneousCheckBox"] ? (byte)Seed.Next(0, 2) : configure.Gender;
                            configure.Race = setting["tailMiscellaneousCheckBox"] ? (byte)Seed.Next(0, 5) : configure.Race;
                            configure.HasRing = setting["ringMiscellaneousCheckBox"] ? (byte)Seed.Next(0, 2) : configure.HasRing;

                            configureWriter.WriteStruct(configure);
                        }
                    }

                    // Replace file content
                    file.Value.ByteContent = memoryStream.ToArray();
                }
            }

            // Remove File if the file exists
            if (File.Exists(OutputPath + "/chara/param/configure.jarc"))
            {
                File.Delete(OutputPath + "/chara/param/configure.jarc");
            }

            // Save
            ConfigureJarc.Save(OutputPath + "/chara/param/configure.jarc");

            // Close File
            ConfigureJarc.Close();
        }

        public void RandomizeBaseParamBin(Dictionary<string, bool> setting)
        {
            string savePath = OutputPath + "/chara/param/base_param.bin";

            string directoryPath = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (BinaryDataWriter baseparamWriter = new BinaryDataWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
            {
                using (BinaryDataReader baseparamReader = new BinaryDataReader(new FileStream(DirectoryPath + "/chara/param/base_param.bin", FileMode.Open)))
                {
                    int characterCount = (int)baseparamReader.Length / 0x54;
                    DBFlogic.BaseParam[] baseParams = baseparamReader.ReadMultipleStruct<DBFlogic.BaseParam>(characterCount);

                    // Priority to swap
                    if (setting["swapCharacterCheckBox"])
                    {
                        List<DBFlogic.BaseParam> baseParamsTemp = baseParams.ToList();

                        for (int i = 0; i < characterCount; i++)
                        {
                            // Save characterID and numberID
                            uint characterID = baseParams[i].CharacterID;
                            int numberID = baseParams[i].NumberID;

                            // Take random character
                            int randomIndex = Seed.Next(baseParamsTemp.Count());
                            DBFlogic.BaseParam randomCharacter = baseParamsTemp[randomIndex];

                            // Swap current character loaded by random character
                            baseParams[i] = randomCharacter;

                            // Reassignment of characterID and numberID
                            baseParams[i].CharacterID = characterID;
                            baseParams[i].NumberID = numberID;

                            baseParamsTemp.RemoveAt(randomIndex);
                        }
                    }

                    // Randomize
                    for (int i = 0; i < characterCount; i++)
                    {
                        // Randomize information
                        baseParams[i].Rank = setting["rankCheckBox"] ? (byte)Seed.Next(0, 5) : baseParams[i].Rank;
                        baseParams[i].Race = setting["raceCheckBox"] ? (byte)Seed.Next(0, 5) : baseParams[i].Race;
                        baseParams[i].Gender = setting["genderCheckBox"] ? (byte)Seed.Next(0, 2) : baseParams[i].Gender;
                        baseParams[i].SpecialPose = setting["poseCheckBox"] ? (byte)Seed.Next(0, 47) : baseParams[i].SpecialPose;
                        if (setting["skillsCheckBox"])
                        {
                            List<int> randomIndex = Seed.GetNumbers(0, Skill.Skills.Count, 3);
                            baseParams[i].SkillsID[0] = Skill.Skills.ElementAt(randomIndex[0]).Key;
                            baseParams[i].SkillsID[1] = Skill.Skills.ElementAt(randomIndex[1]).Key;
                            baseParams[i].SkillsID[2] = Skill.Skills.ElementAt(randomIndex[2]).Key;
                        }

                        // Randomize stats
                        baseParams[i].BaseStat.HP = setting["hpCheckBox"] ? Seed.Next(800, 1101) : baseParams[i].BaseStat.HP;
                        baseParams[i].BaseStat.Melee = setting["meleeCheckBox"] ? (short)Seed.Next(85, 116) : baseParams[i].BaseStat.Melee;
                        baseParams[i].BaseStat.KiBlast = setting["kiBlastCheckBox"] ? (short)Seed.Next(85, 116) : baseParams[i].BaseStat.KiBlast;
                        baseParams[i].BaseStat.Defense = setting["defenseCheckBox"] ? (short)Seed.Next(85, 116) : baseParams[i].BaseStat.Defense;
                        baseParams[i].BaseStat.Luck = setting["luckCheckBox"] ? (short)(Seed.Next(0, 11) * 10) : baseParams[i].BaseStat.Luck;

                        // Randomize model and more
                        baseParams[i].FightingStyleID = setting["styleCheckBox"] ? Style.Styles[Seed.Next(0, Style.Styles.Count)] : baseParams[i].FightingStyleID;
                        baseParams[i].ModelID = setting["modelCheckBox"] ? Model.Models[Seed.Next(0, Model.Models.Count)] : baseParams[i].ModelID;
                        baseParams[i].NameID = setting["nameCheckBox"] ? Name.Names[Seed.Next(0, Name.Names.Count)] : baseParams[i].NameID;
                        baseParams[i].DescriptionID = setting["descriptionCheckBox"] ? Description.Descriptions[Seed.Next(0, Description.Descriptions.Count)] : baseParams[i].DescriptionID;
                        baseParams[i].VoiceID = setting["voiceCheckBox"] ? Voice.Voices[Seed.Next(0, Voice.Voices.Count)] : baseParams[i].VoiceID;

                        // Generate probabilities to know if the character can get a transformation
                        if (setting["transformationCheckBox"])
                        {
                            switch (Seed.Probability(new int[] { 10, 90 }))
                            {
                                case 0:
                                    baseParams[i].TransormationID = 0x0;
                                    break;
                                case 1:
                                    baseParams[i].TransormationID = Model.Models[Seed.Next(0, Model.Models.Count)];
                                    break;
                            }
                        }
                    }

                    // Write
                    baseparamWriter.WriteMultipleStruct(baseParams);
                }
            }
        }

        public void RandomizeSkillLearnParamBin(Dictionary<string, bool> setting)
        {
            string savePath = OutputPath + "/battle/pac/chara_ex_skill_learn_param.bin";

            string directoryPath = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (BinaryDataWriter learnparamWriter = new BinaryDataWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
            {
                using (BinaryDataReader learnparamReader = new BinaryDataReader(new FileStream(DirectoryPath + "/battle/pac/chara_ex_skill_learn_param.bin", FileMode.Open)))
                {
                    int characterCount = (int)learnparamReader.Length / 0x88;
                    DBFlogic.LearnParam[] learnParams = learnparamReader.ReadMultipleStruct<DBFlogic.LearnParam>(characterCount);

                    // Randomize
                    if (setting["learnableSkillCheckBox"])
                    {
                        for (int i = 0; i < characterCount; i++)
                        {
                            // Generate random moveset
                            List<int> randomIndex = Seed.GetNumbers(0, SpecialMove.SpecialMoves.Count, 16);

                            for (int j = 0; j < 16; j++)
                            {
                                learnParams[i].Skills[j].SkillID = SpecialMove.SpecialMoves[randomIndex[j]];
                            }
                        }
                    }

                    // Write
                    learnparamWriter.WriteMultipleStruct(learnParams);
                }
            }
        }
    }
}
