using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
{
    public static class Extension
    {
        public static byte[] AppendCRC8(this byte[] bytes)
        {
            return bytes.Concat(new byte[] { ByteUtils.CRC(bytes) }).ToArray<byte>();
        }

        public static void Invoke<TControl>(this TControl control, Action action) where TControl : Control
        {
            if (!control.InvokeRequired)
            {
                action();
            }
            else
            {
                control.Invoke(action);
            }
        }
    }
}
