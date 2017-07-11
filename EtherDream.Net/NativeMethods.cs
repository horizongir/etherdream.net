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
        internal static extern int EtherDreamGetStatus(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamStop(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamCloseDevice(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EtherDreamClose();

        /* EasyLase API */
        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseGetCardNum();

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseWriteFrame(ref int CardNum, [In]EasyLasePoint[] data, int Bytes, ushort PPS);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseWriteFrameNR(ref int CardNum, [In]EasyLasePoint[] data, int Bytes, ushort PPS, ushort Reps);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseGetLastError(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseGetStatus(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseStop(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseClose();

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseWriteDMX(ref int CardNum, [In]byte[] data);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseGetDMX(ref int CardNum, [In]byte[] data);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseDMXOut(ref int CardNum, [In]byte[] data, ushort Baseaddress, ushort ChannelCount);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseDMXIn(ref int CardNum, [In]byte[] data, ushort Baseaddress, ushort ChannelCount);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseWriteTTL(ref int CardNum, ushort TTLValue);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EasyLaseGetDebugInfo(ref int CardNum, IntPtr data, ushort count);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseSend(ref int CardNum, [In]EasyLasePoint[] data, int Bytes, ushort KPPS);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseWriteFrameUncompressed(ref int CardNum, [In]EasyLasePoint[] data, int Bytes, ushort PPS);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EasyLaseReConnect();

        /* EzAudDac API */
        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EzAudDacGetCardNum();

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EzAudDacWriteFrame(ref int CardNum, [In]EtherDreamPoint[] data, int Bytes, ushort PPS);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EzAudDacWriteFrameNR(ref int CardNum, [In]EtherDreamPoint[] data, int Bytes, ushort PPS, ushort Reps);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern int EzAudDacGetStatus(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EzAudDacStop(ref int CardNum);

        [DllImport(libName, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EzAudDacClose();
    }
}
