using System;
using System.Runtime.InteropServices;

namespace DBFrandomizer.Logic
{
    public static class DBFlogic
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RGB
        {
            public float R;
            public float G;
            public float B;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Configure
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x06)]
            public byte[] FileName1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0A)]
            public byte[] FileName2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] UnkBlock1;
            public RGB SkinColor;
            public RGB GlovesColor;
            public RGB Hair1Color;
            public RGB Hair2Color;
            public RGB Top1Color;
            public RGB Top2Color;
            public RGB Bottom1Color;
            public RGB Bottom2Color;
            public RGB Boots1Color;
            public RGB Boots2Color;
            public RGB TailColor;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x30)]
            public byte[] UnkBlock2;
            public RGB EyesColor;
            public RGB UnkColor;
            public RGB AuraColor;
            public uint TopID;
            public uint BottomID;
            public uint FaceFormID;
            public uint HairID;
            public uint FaceID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] UnkBlock3;
            public int BodyID;
            public byte HasTail;
            public byte Gender;
            public byte Race;
            public byte HasRing;
            public uint Unk;
        }

        public struct Stat
        {
            public int HP;
            public short Melee;
            public short KiBlast;
            public short Defense;
            public short Luck;
        }

        public struct LearnSkill
        {
            public uint SkillID;
            public uint Unk;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BaseParam
        {
            public uint CharacterID;
            private byte Unk1;
            public byte Rank;
            private byte Unk2;
            public byte Race;
            private byte Unk3;
            public byte Gender;
            private byte Unk4;
            public byte SpecialPose;
            public uint FightingStyleID;
            public uint ModelID;
            public uint TransormationID;
            public uint NameID;
            public uint DescriptionID;
            public uint VoiceID;
            public Stat BaseStat;
            public Stat GrownStat;
            public uint Unk5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x03)]
            public uint[] SkillsID;
            public int NumberID;
            public uint Unk6;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LearnParam
        {
            public uint CharacterID;
            public uint Unk1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public LearnSkill[] Skills;
        }
    }
}
