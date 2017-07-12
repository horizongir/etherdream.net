using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EtherDream.Net
{
    /// <summary>
    /// Specifies Ether Dream device status.
    /// </summary>
    public enum EtherDreamStatus
    {
        /// <summary>
        /// Specifies that the device is ready to receive data and control messages.
        /// </summary>
        Ready = 1,

        /// <summary>
        /// Specifies that the device is busy executing previous commands.
        /// </summary>
        Busy = 2
    }

    /// <summary>
    /// Represents an individual control point for laser trajectories.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EtherDreamPoint
    {
        /// <summary>
        /// The x-coordinate of the control point.
        /// </summary>
        public short X;

        /// <summary>
        /// The y-coordinate of the control point.
        /// </summary>
        public short Y;

        /// <summary>
        /// The red component of the laser color at the control point.
        /// </summary>
        public short R;

        /// <summary>
        /// The green component of the laser color at the control point.
        /// </summary>
        public short G;

        /// <summary>
        /// The blue component of the laser color at the control point.
        /// </summary>
        public short B;

        /// <summary>
        /// The intensity of the laser at the control point.
        /// </summary>
        public short I;

        /// <summary>
        /// Unused/unknown.
        /// </summary>
        public short AL;
        
        /// <summary>
        /// Unused/unknown.
        /// </summary>
        public short AR;
    }
}
