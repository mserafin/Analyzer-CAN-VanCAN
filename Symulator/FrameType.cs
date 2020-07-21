using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public enum FrameType
    {
        CONFIG_UART = 0x01,
        CONFIG_CAN = 0x02,
        SYNC_TIME = 0x03,
        FRAME_STANDARD = 0x04,
        FRAME_EXTENDED = 0x05
    }
}
