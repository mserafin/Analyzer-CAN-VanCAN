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

        public static T[] Slice<T>(this T[] source, int indexStart, int indexEnd)
        {
            indexEnd = indexEnd < 0 ? source.Length + indexEnd : indexEnd;

            var l = indexEnd - indexStart;

            var copy = new T[l];
            for (var i = 0; i < l; i++)
            {
                copy[i] = source[i + indexStart];
            }

            return copy;
        }

        //public static T[] Slice<T>(this T[] source, int index, int length)
        //{
        //    var copy = new T[length];

        //    for (var i = 0; i < length; i++)
        //    {
        //        copy[i] = source[i + index];
        //    }

        //    return copy;
        //}
    }
}
