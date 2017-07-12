using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    static class NativeMethods
    {
        const string libName = "EtherDream";

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EtherDreamGetCardNum();

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void EtherDreamGetDeviceName(ref int CardNum, [Out]byte[] buf, int max);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamOpenDevice(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamWriteFrame(ref int CardNum, [In]EtherDreamPoint[] data, int Bytes, ushort PPS, ushort Reps);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern EtherDreamStatus EtherDreamGetStatus(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamStop(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamCloseDevice(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamClose();
    }
}
