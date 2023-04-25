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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] UnkBlock1;
            public int Count;
            public int Offset;
            public int Size;
        }
    }
}
