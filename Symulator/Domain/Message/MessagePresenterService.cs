using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Symulator.Domain.Message
{
    public class MessagePresenterService : IMessageService
    {
        private readonly List<ViewMessage> storage = new List<ViewMessage>();
        private readonly BindingList<ViewMessage> source;

        public readonly DateTime startService = DateTime.Now;

        public MessagePresenterService(Action<BindingList<ViewMessage>> action)
        {
            source = new BindingList<ViewMessage>(storage);
            action?.Invoke(source);
        }

        public void Append(byte[] frame)
        {
            var message = Message.Builder()
                .WithFrame(frame)
                .Build();

            var viewMessage = FindMessageInStorage(message);
            if (viewMessage is null)
            {
                AddViewMessage(message);
            }
            else
            {
                EditViewMessage(message, viewMessage);
            }
        }

        private ViewMessage FindMessageInStorage(Message message)
        {
            return storage.SingleOrDefault(it => (it.CanNo == message.CanNo && it.CanId == message.CanId));
        }

        private void AddViewMessage(Message m)
        {
            var vm = ViewMessage.Builder()
                .WithMessage(m.Clone() as Message)
                .WithDirection(DirectionType.Rx)
                .WithPeriod(GetDiffTime(m.DateStamp, DateTime.Now))
                .WithCount(1)
                .Build();

            source.Add(vm);
            storage.Sort((a, b) => b.CanId.CompareTo(a.CanId));
            source.ResetBindings();
        }

        private void EditViewMessage(Message m, ViewMessage vm)
        {
            ViewMessage.Editor(vm)
                .WithData(m.Data)
                .WithDataLength(m.DataLength)
                .WithAscii(m.ASCII)
                .WithCount(vm.Count + 1)
                .WithTime(GetDiffTime(m.DateStamp, startService))
                .WithPeriod(GetDiffTime(m.DateStamp, vm.TimeStamp))
                .WithTimeStamp(m.DateStamp)
                .Build();
        }

        private TimeSpan GetDiffTime(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Subtract(dateTime2);
        }
    }
}
