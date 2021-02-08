using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Symulator.Domain.Message
{
    public class ViewMessage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string data;
        private int dataLength;
        private ulong count;
        private int period;
        private string ascii;
        private ulong time;

        public uint CanNo { private set; get; }
        public uint CanId { private set; get; }
        public string Data
        {
            private set
            {
                if (data != value)
                {
                    data = value;
                    NotifyPropertyChanged();
                }
            }
            get { return data; }
        }
        public int DataLength
        {
            private set
            {
                if (dataLength != value)
                {
                    dataLength = value;
                    NotifyPropertyChanged();
                }
            }
            get { return dataLength; }
        }
        public string Extended { private set; get; }
        public string ASCII
        {
            private set
            {
                if (ascii != value)
                {
                    ascii = value;
                    NotifyPropertyChanged();
                }
            }
            get { return ascii; }
        }
        public string Direction { private set; get; }
        public int Period
        {
            private set
            {
                if (period != value)
                {
                    period = value;
                    NotifyPropertyChanged();
                }
            }
            get { return period; }
        }
        public ulong Count
        {
            private set
            {
                if (count != value)
                {
                    count = value;
                    NotifyPropertyChanged();
                }
            }
            get { return count; }
        }
        public ulong Time
        {
            private set
            {
                if (time != value)
                {
                    time = value;
                    NotifyPropertyChanged();
                }
            }
            get { return time; }
        }
        public DateTime TimeStamp { private set; get; }

        private ViewMessage(ViewMessageBuilder builder)
        {
            CanNo = builder.CanNo;
            CanId = builder.CanId;
            Data = builder.Data;
            DataLength = builder.DataLength;
            Extended = builder.Extended;
            ASCII = builder.Ascii;
            Direction = builder.Direction;
            Period = builder.Period;
            Count = builder.Count;
            Time = builder.Time;
            TimeStamp = builder.TimeStamp;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ViewMessageEditor Editor(ViewMessage vm)
        {
            return new ViewMessageEditor(vm);
        }

        public static ViewMessageBuilder Builder()
        {
            return new ViewMessageBuilder();
        }

        public sealed class ViewMessageBuilder
        {
            public uint CanNo { private set; get; }
            public uint CanId { private set; get; }
            public string Data { private set; get; }
            public int DataLength { private set; get; }
            public string Ascii { private set; get; }
            public string Extended { private set; get; }
            public string Direction { private set; get; }
            public ulong Count { private set; get; }
            public int Period { private set; get; }
            public ulong Time { private set; get; }
            public DateTime TimeStamp { private set; get; }

            public ViewMessageBuilder WithMessage(Message message)
            {
                WithCanNo(message.CanNo)
                    .WithCanId(message.CanId)
                    .WithData(message.Data)
                    .WithDataLength(message.DataLength)
                    .WithAscii(message.ASCII)
                    .WithExtended(message.IsExtended)
                    .WithTimeStamp(message.DateStamp);

                return this;
            }
            public ViewMessageBuilder WithCanNo(uint canNo)
            {
                CanNo = canNo;
                return this;
            }
            public ViewMessageBuilder WithCanId(uint canId)
            {
                CanId = canId;
                return this;
            }
            public ViewMessageBuilder WithData(byte[] data)
            {
                Data = string.Join(" ", data.Select(it => it.ToString("X2")));
                return this;
            }
            public ViewMessageBuilder WithDataLength(int dataLength)
            {
                DataLength = dataLength;
                return this;
            }
            public ViewMessageBuilder WithExtended(bool extended)
            {
                Extended = extended ? "Y" : "N";
                return this;
            }
            public ViewMessageBuilder WithAscii(string ascii)
            {
                Ascii = ascii;
                return this;
            }
            public ViewMessageBuilder WithTime(TimeSpan timeSpan)
            {
                Time = Convert.ToUInt64(timeSpan.TotalSeconds);
                return this;
            }
            public ViewMessageBuilder WithTimeStamp(DateTime dateStamp)
            {
                TimeStamp = dateStamp;
                return this;
            }
            public ViewMessageBuilder WithDirection(DirectionType direction)
            {
                Direction = direction.ToString();
                return this;
            }
            public ViewMessageBuilder WithPeriod(TimeSpan period)
            {
                Period = period.Milliseconds;
                return this;
            }
            public ViewMessageBuilder WithCount(uint count)
            {
                Count = count;
                return this;
            }
            public ViewMessage Build()
            {
                return new ViewMessage(this);
            }
        }

        public sealed class ViewMessageEditor
        {
            public ViewMessage ViewMessage { private set; get; }

            public ViewMessageEditor(ViewMessage vm)
            {
                ViewMessage = vm;
            }
            public ViewMessageEditor WithMessage(Message message)
            {
                WithCanNo(message.CanNo)
                    .WithCanId(message.CanId)
                    .WithData(message.Data)
                    .WithDataLength(message.DataLength)
                    .WithExtended(message.IsExtended)
                    .WithAscii(message.ASCII)
                    .WithTimeStamp(message.DateStamp);

                return this;
            }
            public ViewMessageEditor WithCanNo(uint canNo)
            {
                ViewMessage.CanNo = canNo;
                return this;
            }
            public ViewMessageEditor WithCanId(uint canId)
            {
                ViewMessage.CanId = canId;
                return this;
            }
            public ViewMessageEditor WithData(byte[] data)
            {
                ViewMessage.Data = string.Join(" ", data.Select(it => it.ToString("X2")));
                return this;
            }
            public ViewMessageEditor WithDataLength(int dataLength)
            {
                ViewMessage.DataLength = dataLength;
                return this;
            }
            public ViewMessageEditor WithExtended(bool extended)
            {
                ViewMessage.Extended = extended ? "Y" : "N";
                return this;
            }
            public ViewMessageEditor WithAscii(string ascii)
            {
                ViewMessage.ASCII = ascii;
                return this;
            }
            public ViewMessageEditor WithTime(TimeSpan timeSpan)
            {
                ViewMessage.Time = Convert.ToUInt64(timeSpan.TotalSeconds);
                return this;
            }
            public ViewMessageEditor WithTimeStamp(DateTime dateStamp)
            {
                ViewMessage.TimeStamp = dateStamp;
                return this;
            }
            public ViewMessageEditor WithDirection(DirectionType direction)
            {
                ViewMessage.Direction = direction.ToString();
                return this;
            }
            public ViewMessageEditor WithPeriod(TimeSpan period)
            {
                ViewMessage.Period = period.Milliseconds;
                return this;
            }
            public ViewMessageEditor WithCount(ulong count)
            {
                ViewMessage.Count = count;
                return this;
            }
            public ViewMessage Build()
            {
                return ViewMessage;
            }
        }
    }
}
