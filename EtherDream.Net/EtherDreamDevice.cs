using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    /// <summary>
    /// Represents an Ether Dream device.
    /// </summary>
    public class EtherDreamDevice : IDisposable
    {
        const int DeviceNameMaxLength = 256;
        int cardNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtherDreamDevice"/> class
        /// controlling the specified device number.
        /// </summary>
        /// <param name="number">The Ether Dream device number.</param>
        public EtherDreamDevice(int number)
        {
            cardNumber = number;
        }

        /// <summary>
        /// Gets the device name.
        /// </summary>
        public string Name
        {
            get
            {
                var buffer = new byte[DeviceNameMaxLength];
                NativeMethods.EtherDreamGetDeviceName(ref cardNumber, buffer, DeviceNameMaxLength);
                return Encoding.ASCII.GetString(buffer, 0, Array.IndexOf<byte>(buffer, 0));
            }
        }

        /// <summary>
        /// Gets the ether dream device status.
        /// </summary>
        public EtherDreamStatus Status
        {
            get { return NativeMethods.EtherDreamGetStatus(ref cardNumber); }
        }

        /// <summary>
        /// Opens a connection to the Ether Dream device.
        /// </summary>
        public void Open()
        {
            if (!NativeMethods.EtherDreamOpenDevice(ref cardNumber))
            {
                throw new InvalidOperationException("Error opening EtherDream device.");
            }
        }

        /// <summary>
        /// Writes a data frame to the Ether Dream device.
        /// </summary>
        /// <param name="data">The array of control points to send to the device.</param>
        /// <param name="pointsPerSecond">The rate at which the device should draw the control points.</param>
        /// <param name="repetitions">
        /// How many times should the array be drawn by the device. A value of -1 specifies
        /// infinite repetitions.
        /// </param>
        /// <returns><b>true</b> if the data frame was successfully transmitted; <b>false</b> otherwise.</returns>
        public bool WriteFrame(EtherDreamPoint[] data, int pointsPerSecond, int repetitions)
        {
            return NativeMethods.EtherDreamWriteFrame(
                ref cardNumber,
                data, data.Length * Marshal.SizeOf(typeof(EtherDreamPoint)),
                (ushort)pointsPerSecond,
                (ushort)repetitions);
        }

        /// <summary>
        /// Stops communication with the Ether Dream device.
        /// </summary>
        /// <returns><b>true</b> if the communication was successfully interrupted; <b>false</b> otherwise.</returns>
        public bool Stop()
        {
            return NativeMethods.EtherDreamStop(ref cardNumber);
        }

        /// <summary>
        /// Closes the connection to the Ether Dream device.
        /// </summary>
        public void Close()
        {
            if (!NativeMethods.EtherDreamCloseDevice(ref cardNumber))
            {
                throw new InvalidOperationException("Error closing EtherDream device.");
            }
        }

        /// <summary>
        /// Gets an array of the Ether Dream devices which are currently
        /// connected into the computer.
        /// </summary>
        /// <returns>
        /// An array of <see cref="EtherDreamDevice"/> instances representing the devices
        /// which are currently connected into the computer.
        /// </returns>
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
