using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public static class ByteUtils
    {
        public static byte CRC(byte[] bytes)
        {
            byte crc = 0x00;

            for (int i = 0, l = bytes.Length; i < l; i++)
            {
                var extract = bytes[i];

                for (byte j = 8; j > 0; j--)
                {
                    var sum = (byte)(crc ^ extract) & 0x01;

                    crc >>= 1;

                    if (sum != 0)
                    {
                        crc ^= 0x8C;
                    }

                    extract >>= 1;
                }
            }
            return crc;
        }
    }
}
