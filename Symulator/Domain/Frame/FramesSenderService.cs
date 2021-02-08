using System;
using System.Threading;

namespace Symulator
{
    public class FramesSenderService
    {
        private ISenderIterator iterator;

        public event EventHandler<SenderData> SendData;

        public bool IsEnabled { get; private set; }

        public FramesSenderService(ISenderIterator iterator)
        {
            this.iterator = iterator;
        }

        public void Enabled()
        {
            IsEnabled = true;

            (new Thread(() =>
            {
                while (IsEnabled && iterator.HasNext())
                {
                    var data = iterator.Next();
                    if (data.Data.Length > 0 && DateUtils.isDelaying(data.LastMillis, data.Interval))
                    {
                        SendData?.Invoke(this, data);
                        data.LastMillis = DateTime.Now.Ticks;
                        Thread.Sleep(100);
                    }
                }
            })).Start();
        }

        public void Disabled()
        {
            IsEnabled = false;
        }
    }
}
