using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EtherDreamPoint
    {
        public short X;
        public short Y;
        public short R;
        public short G;
        public short B;
        public short I;
        public short AL;
        public short AR;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EasyLasePoint
    {
        public ushort X;
        public ushort Y;
        public byte R;
        public byte G;
        public byte B;
        public byte I;
    }
}
