using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    public enum EtherDreamStatus
    {
        Ready = 1,
        Busy = 2
    }

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
}
