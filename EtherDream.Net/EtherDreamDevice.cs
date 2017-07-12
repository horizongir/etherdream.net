using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    public class EtherDreamDevice : IDisposable
    {
        const int DeviceNameMaxLength = 256;
        int cardNumber;

        private EtherDreamDevice(int number)
        {
            cardNumber = number;
        }

        public string Name
        {
            get
            {
                var buffer = new byte[DeviceNameMaxLength];
                NativeMethods.EtherDreamGetDeviceName(ref cardNumber, buffer, DeviceNameMaxLength);
                return Encoding.ASCII.GetString(buffer, 0, Array.IndexOf(buffer, 0));
            }
        }

        public int Status
        {
            get { return NativeMethods.EtherDreamGetStatus(ref cardNumber); }
        }

        public void Open()
        {
            if (!NativeMethods.EtherDreamOpenDevice(ref cardNumber))
            {
                throw new InvalidOperationException("Error opening EtherDream device.");
            }
        }

        public void WriteFrame(EtherDreamPoint[] data, int pointsPerSecond, int repetitions)
        {
            if (!NativeMethods.EtherDreamWriteFrame(ref cardNumber, data, data.Length, (ushort)pointsPerSecond, (ushort)repetitions))
            {
                throw new InvalidOperationException("Error writing data frame to EtherDream device.");
            }
        }

        public void Stop()
        {
            if (!NativeMethods.EtherDreamStop(ref cardNumber))
            {
                throw new InvalidOperationException("Error stopping EtherDream device.");
            }
        }

        public void Close()
        {
            if (!NativeMethods.EtherDreamCloseDevice(ref cardNumber))
            {
                throw new InvalidOperationException("Error closing EtherDream device.");
            }
        }

        public static EtherDreamDevice[] GetDevices()
        {
            var count = NativeMethods.EtherDreamGetCardNum();
            var devices = new EtherDreamDevice[count];
            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = new EtherDreamDevice(i);
            }

            return devices;
        }

        void IDisposable.Dispose()
        {
            Close();
        }
    }
}
