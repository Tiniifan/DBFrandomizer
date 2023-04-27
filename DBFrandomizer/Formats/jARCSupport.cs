using System;
using System.Runtime.InteropServices;

namespace DBFrandomizer.Formats
{
    public static class jARCSupport
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Header
        {
            public UInt32 Magic;
            public int Length;
            private int Unk1;
            public int FileCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FileEntry
        {
            public int Offset;
            public int Size;
            public uint Unk1;
            public uint Hash1;
            public uint Hash2;
        }
    }
}
