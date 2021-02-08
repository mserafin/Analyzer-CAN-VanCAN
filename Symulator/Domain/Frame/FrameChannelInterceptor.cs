using Symulator.Domain.Message;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Symulator.Domain.Frame
{
    public class FrameChannelInterceptor : IFrameInterceptor<byte[]>
    {
        private readonly Channel<byte[]> listener = Channel.CreateUnbounded<byte[]>();
        private readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private readonly List<IMessageService> subscribers = new List<IMessageService>();

        public FrameChannelInterceptor()
        {
            Task.Run(async () =>
            {
                while (await listener.Reader.WaitToReadAsync(cancellationToken.Token))
                {
                    var frame = await listener.Reader.ReadAsync();
                    Publish(frame);

                    Console.WriteLine($"Frame: {string.Join(" ", frame)}\n");
                }
            });
        }

        public void Apply(byte[] frame, bool isCorrect)
        {
            if (isCorrect)
            {
                listener.Writer.TryWrite(frame);
            }
        }

        public void Subscribe(IMessageService messageService)
        {
            subscribers.Add(messageService);
        }

        private void Publish(byte[] frame)
        {
            subscribers.ForEach(it => it.Append(frame));
        }

        ~FrameChannelInterceptor()
        {
            cancellationToken.Cancel();
        }
    }
}
