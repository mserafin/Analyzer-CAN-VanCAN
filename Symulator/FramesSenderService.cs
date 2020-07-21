using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Symulator
{
    public delegate void EventHandler(SenderData frame);

    public class FramesSenderService
    {
        private ISenderIterator iterator;

        public event EventHandler SendData;

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
                        //Console.WriteLine("CanId: {0}, Time: {1}", data.CanId, (DateTime.Now.Ticks - data.LastMillis) / 10000);
                        SendData?.Invoke(data);
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
