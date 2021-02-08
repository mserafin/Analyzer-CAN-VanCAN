using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Domain.Message
{
    public sealed class Message : ICloneable
    {
        public uint CanNo { private set; get; } = 0;

        public uint CanId { private set; get; } = 0;

        public byte[] Data { private set; get; } = { };

        public byte DataLength { private set; get; } = 0;

        public bool IsExtended { private set; get; } = false;

        public DateTime DateStamp { private set; get; } = DateTime.Now;

        public byte D0
        {
            get
            {
                return getDataByIndex(0);
            }
        }

        public byte D1
        {
            get
            {
                return getDataByIndex(1);
            }
        }

        public byte D2
        {
            get
            {
                return getDataByIndex(2);
            }
        }

        public byte D3
        {
            get
            {
                return getDataByIndex(3);
            }
        }

        public byte D4
        {
            get
            {
                return getDataByIndex(4);
            }
        }

        public byte D5
        {
            get
            {
                return getDataByIndex(5);
            }
        }

        public byte D6
        {
            get
            {
                return getDataByIndex(6);
            }
        }

        public byte D7
        {
            get
            {
                return getDataByIndex(7);
            }
        }

        public string ASCII
        {
            get
            {
                return Encoding.ASCII.GetString(Data);
            }
        }

        private byte getDataByIndex(int index)
        {
            return Data.ElementAtOrDefault(index);
        }

        private Message(MessageBuilder builder)
        {
            this.CanNo = builder.CanNo;
            this.CanId = builder.CanId;
            this.Data = builder.Data;
            this.DataLength = builder.DataLength;
            this.IsExtended = this.CanId > 0x7FF;
        }

        public static MessageBuilder Builder()
        {
            return new MessageBuilder();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public sealed class MessageBuilder
        {
            public uint CanNo { private set; get; } = 0;

            public uint CanId { private set; get; } = 0;

            public byte[] Data { private set; get; } = { };

            public byte DataLength { private set; get; } = 0;

            public MessageBuilder WithCanNo(uint canNo)
            {
                this.CanNo = canNo;
                return this;
            }

            public MessageBuilder WithCanId(uint canId)
            {
                this.CanId = canId;
                return this;
            }

            public MessageBuilder WithData(byte[] data)
            {
                this.Data = data;
                return this;
            }

            public MessageBuilder WithDataLength(byte dataLength)
            {
                this.DataLength = dataLength;
                return this;
            }

            public MessageBuilder WithFrame(byte[] data)
            {
                var bytesCanId = data.Slice(0, 4);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesCanId);

                this.WithCanId(BitConverter.ToUInt32(bytesCanId, 0))
                    .WithDataLength(data.ElementAtOrDefault(4))
                    .WithData(data.Slice(5, this.DataLength + 5));

                return this;
            }

            public Message Build()
            {
                return new Message(this);
            }
        }
    }
}
