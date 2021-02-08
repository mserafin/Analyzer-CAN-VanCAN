using Symulator.Domain.Message;
using System.Collections.Generic;

namespace Symulator.Domain.Frame
{
    public class FrameActionInterceptor : IFrameInterceptor<byte[]>
    {
        private readonly List<IMessageService> subscribers = new List<IMessageService>();

        public void Apply(byte[] frame, bool isCorrect)
        {
            if (isCorrect)
            {
                subscribers.ForEach(it => it.Append(frame));
            }
        }

        public void Subscribe(IMessageService messageService)
        {
            subscribers.Add(messageService);
        }
    }
}
