using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFrandomizer.Formats;
using DBFrandomizer.Tool;
using DBFrandomizer.Logic;
using DBFrandomizer.Common;

namespace DBFrandomizer
{
    public partial class RandomizerWindow : Form
    {
        private jARC ConfigureJarc;

        private RandomNumber Seed = new RandomNumber();

        public RandomizerWindow()
        {
            InitializeComponent();
        }

        private DBFlogic.RGB RandomRGB()
        {
            DBFlogic.RGB rgb = new DBFlogic.RGB();

            rgb.R = Seed.Next(256);
            rgb.G = Seed.Next(256);
            rgb.B = Seed.Next(256);

            return rgb;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jARC files (*.jarc)|*.jarc";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ConfigureJarc = new jARC(new FileStream(openFileDialog1.FileName, FileMode.Open));

                tabControl1.Enabled = true;
                randomizeToolStripMenuItem.Enabled = true;
            }
        }

        private void RandomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                            configure.TopID = topCheckBox.Checked ? Common.Top.Tops.ElementAt(Seed.Next(0, Common.Top.Tops.Count)).Key : configure.TopID;
                            configure.HairID = hairCheckBox.Checked ? Common.Hair.Hairs.ElementAt(Seed.Next(0, Common.Hair.Hairs.Count)).Key : configure.HairID;
                            configure.FaceID = faceCheckBox.Checked ? Common.Face.Faces.ElementAt(Seed.Next(0, Common.Face.Faces.Count)).Key : configure.FaceID;
                            configure.BottomID = bottomCheckBox.Checked ? Common.Bottom.Bottoms.ElementAt(Seed.Next(0, Common.Bottom.Bottoms.Count)).Key : configure.BottomID;
                            configure.BodyID = bodyCheckBox.Checked ? Seed.Next(0, 22) : configure.BodyID;
                            configure.FaceFormID = faceFormCheckBox.Checked ? Common.FaceForm.FaceForms.ElementAt(Seed.Next(0, Common.FaceForm.FaceForms.Count)).Key : configure.FaceFormID;

                            // Randomize color
                            configure.Top1Color = topColorCheckBox.Checked ? RandomRGB() : configure.Top1Color;
                            configure.Top2Color = topColorCheckBox.Checked ? RandomRGB() : configure.Top2Color;
                            configure.Hair1Color = hairColorCheckBox.Checked ? RandomRGB() : configure.Hair1Color;
                            configure.Hair2Color = hairColorCheckBox.Checked ? RandomRGB() : configure.Hair2Color;
                            configure.SkinColor = skinColorCheckBox.Checked ? RandomRGB() : configure.SkinColor;
                            configure.Bottom1Color = bottomColorCheckBox.Checked ? RandomRGB() : configure.Bottom1Color;
                            configure.Bottom2Color = bottomColorCheckBox.Checked ? RandomRGB() : configure.Bottom2Color;
                            configure.Boots1Color = bootsColorCheckBox.Checked ? RandomRGB() : configure.Boots1Color;
                            configure.Boots2Color = bootsColorCheckBox.Checked ? RandomRGB() : configure.Boots2Color;
                            configure.EyesColor = eyesColorCheckBox.Checked ? RandomRGB() : configure.EyesColor;
                            configure.GlovesColor = glovesColorCheckBox.Checked ? RandomRGB() : configure.GlovesColor;
                            configure.TailColor = tailColorCheckBox.Checked ? RandomRGB() : configure.TailColor;
                            configure.AuraColor = auraColorCheckBox.Checked ? RandomRGB() : configure.AuraColor;

                            // Randomize Miscellaneous
                            configure.HasTail = tailMiscellaneousCheckBox.Checked ? (byte)Seed.Next(0, 2): configure.HasTail;
                            configure.Gender = genderMiscellaneousCheckBox.Checked ? (byte)Seed.Next(0, 2) : configure.Gender;
                            configure.Race = tailMiscellaneousCheckBox.Checked ? (byte)Seed.Next(0, 5) : configure.Race;
                            configure.HasRing = ringMiscellaneousCheckBox.Checked ? (byte)Seed.Next(0, 2) : configure.HasRing;

                            configureWriter.WriteStruct(configure);
                        }

                        // Replace file content
                        file.Value.ByteContent = memoryStream.ToArray();
                    }
                }
            }

            // Save archive
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = Path.GetFileName(openFileDialog1.FileName);
            saveFileDialog.Title = "Save jARC file";
            saveFileDialog.Filter = "jARC files (*.jarc)|*.jarc";
            saveFileDialog.InitialDirectory = openFileDialog1.InitialDirectory;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == saveFileDialog.FileName)
                {
                    // Save
                    ConfigureJarc.Save(saveFileDialog.FileName + ".temp");

                    // Close File
                    ConfigureJarc.Close();

                    if (File.Exists(openFileDialog1.FileName))
                    {
                        File.Delete(openFileDialog1.FileName);
                    }

                    File.Move(saveFileDialog.FileName + ".temp", saveFileDialog.FileName);

                    // Re Open
                    ConfigureJarc = new jARC(new FileStream(saveFileDialog.FileName, FileMode.Open));
                }
                else
                {
                    ConfigureJarc.Save(saveFileDialog.FileName);
                }

                MessageBox.Show("Saved!");
            }
        }
    }
}
