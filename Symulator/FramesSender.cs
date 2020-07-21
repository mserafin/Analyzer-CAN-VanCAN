using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public class SenderData
    {
        public MessageType CanId;
        public byte[] Data;
        public int Interval;
        public long LastMillis;
    }

    public interface ISenderIterator
    {
        SenderData Current();
        SenderData Next();
        bool HasNext();
        void Rewind();
    }

    public class SenderIterator : ISenderIterator
    {
        private readonly SenderData[]  data;
        private int index;
        private int lenght;

        public SenderIterator(SenderData[] data)
        {
            this.index = 0;
            this.data = data;
            this.lenght = data.Length;
        }

        public SenderData Current()
        {
            return data[index];
        }

        public bool HasNext()
        {
            return index <= lenght;
        }

        public SenderData Next()
        {
            if (index >= lenght)
            {
                Rewind();
            }

            return data[index++];
        }

        public void Rewind()
        {
            index = 0;
        }
    }

    /// <summary>
    /// Aggregate messages CAN
    /// </summary>
    public class FramesSender
    {
        private readonly List<SenderData> data = new List<SenderData>();

        public void Append(MessageType type, int interval = 100)
        {
            data.Add(new SenderData
            {
                CanId = type,
                Data = new byte[] { },
                Interval = interval,
                LastMillis = DateTime.Now.Ticks
            });
        }

        public void Update(MessageType type, object value)
        {
            var bytes = new byte[8];

            if (type == MessageType.SPEED)
            {
                var _value = Convert.ToInt32(value);
                if (_value > 0)
                {
                    // 100 / 0.1381 = 724 << 4 -> 12 bits [64,45]
                    var speed = Convert.ToInt32(_value / 0.1381);
                    var speedBytes = BitConverter.GetBytes(speed << 4).Take(2).ToArray();
                    bytes = bytes.Take(6).Concat(speedBytes).ToArray();
                }
            }
            else if (type == MessageType.RPM)
            {
                var _value = Convert.ToInt32(value);
                if (_value > 0)
                {
                    // 2000 / 0.246 = 8000 -> 2 bajty [64,31]
                    var rpm = Convert.ToInt32(_value / 0.246);
                    var rpmBytes = BitConverter.GetBytes(rpm);
                    bytes[2] = rpmBytes[0];
                    bytes[3] = rpmBytes[1];
                }
            }

            data.Find(it => it.CanId == type).Data = bytes;
        }

        public ISenderIterator Iterator
        {
            get
            {
                return new SenderIterator(data.ToArray());
            }
        }
    }
}
