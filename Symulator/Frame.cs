using System;
using System.Collections.Generic;
using System.Linq;

namespace Symulator
{
    public sealed class Frame : IFrame
    {
        public List<byte> RawData { private set; get; } = new List<byte>();

        public uint CanId { private set; get; } = 0;

        public byte Length { private set; get; } = 0;

        public byte[] Data { private set; get; } = { };

        public bool IsExtended { private set; get; } = false;

        public FrameType Type { private set; get; } = 0;

        private Frame(FrameBuilder builder)
        {
            this.RawData.Add(builder.FrameType);
            this.RawData.AddRange(builder.CanId);
            this.RawData.Add((byte)builder.Data.Length);
            this.RawData.AddRange(builder.Data);
        }

        private Frame(byte[] bytes)
        {
            this.RawData.AddRange(bytes);

            this.Type = (FrameType)bytes[0];

            if (!this.isValid(bytes))
            {
                return;
            }

            switch (this.Type)
            {
                case FrameType.FRAME_STANDARD: this.dataStandardFrame(bytes); break;
                case FrameType.FRAME_EXTENDED: this.dataExtendedFrame(bytes); break;
            }

        }

        private void dataExtendedFrame(byte[] bytes)
        {
            this.IsExtended = false;
            this.dataFrame(bytes);
        }

        private void dataFrame(byte[] bytes)
        {
            this.Length = bytes[5];

            byte[] data = bytes.Skip(1).Take(4).ToArray();
            this.CanId = BitConverter.ToUInt32(data.Reverse().ToArray(), 0);
            this.Data = bytes.Skip(6).Take(this.Length).ToArray();
        }

        private void dataStandardFrame(byte[] bytes)
        {
            this.IsExtended = true;
            this.dataFrame(bytes);
        }

        private bool isValid(byte[] bytes)
        {
            return ByteUtils.CRC(bytes.Take(bytes.Length - 1).ToArray()) == bytes.Last();
        }

        public static FrameBuilder Builder()
        {
            return new FrameBuilder();
        }

        public sealed class FrameBuilder
        {
            public byte FrameType { private set; get; }

            public byte[] CanId { private set; get; } = { };

            public byte[] Data { private set; get; } = { };

            public bool IsExtended { private set; get; } = false;

            public Frame With(byte[] data)
            {
                return new Frame(data);
            }

            public FrameBuilder WithType(FrameType frameType)
            {
                this.FrameType = (byte)frameType;
                return this;
            }

            //public FrameBuilder WithCanId(short canId)
            //{
            //    this.CanId = BitConverter.GetBytes((short)canId).Reverse().ToArray<byte>();
            //    this.IsExtended = false;
            //    return this;
            //}

            public FrameBuilder WithCanId(int canId)
            {
                this.CanId = BitConverter.GetBytes(canId).Reverse().ToArray<byte>();
                this.IsExtended = true;
                return this;
            }

            public FrameBuilder WithData(byte[] data)
            {
                this.Data = data;
                return this;
            }

            public FrameBuilder WithData(short data)
            {
                this.Data = BitConverter.GetBytes(data).Reverse().ToArray<byte>();
                return this;
            }

            public FrameBuilder WithData(int data)
            {
                this.Data = BitConverter.GetBytes(data).Reverse().ToArray<byte>();
                return this;
            }

            public byte[] Build()
            {
                return (new Frame(this)).RawData.ToArray().AppendCRC8();
            }
        }
    }
}
