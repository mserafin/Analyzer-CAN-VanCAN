using Symulator.Domain.Message;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Symulator.Domain.Frame
{
    public class FrameService : IFrameService
    {
        private const int FRAME_LENGTH = 16;

        private IFrameInterceptor<byte[]> frameInterceptor;

        private readonly Channel<byte[]> inputChannel = Channel.CreateUnbounded<byte[]>();
        private readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public FrameService()
        {
            Task.Run(async () =>
            {
                var buffer = new byte[] { };
                while (await inputChannel.Reader.WaitToReadAsync(cancellationToken.Token))
                {
                    var bytes = await inputChannel.Reader.ReadAsync();
                    buffer = await processAsync(buffer.Concat(bytes).ToArray());
                }
            });
        }

        public void Append(byte[] rawFrames)
        {
            inputChannel.Writer.TryWrite(rawFrames);
        }

        public async Task AppendAsync(byte[] rawFrames)
        {
            await inputChannel.Writer.WriteAsync(rawFrames);
        }

        public void Subscribe(IFrameInterceptor<byte[]> frameInterceptor)
        {
            this.frameInterceptor = frameInterceptor;
        }

        private async Task<byte[]> processAsync(byte[] bytes)
        {
            for (int i = 0, l = bytes.Count(); i < l; i++)
            {
                if (bytes.ElementAt(i).Equals(0xAA) && bytes.ElementAtOrDefault(i + 1).Equals(0x55))
                {
                    if (i + FRAME_LENGTH > l)
                    {
                        return bytes;
                    }

                    var frameBytes = bytes.Slice(i, i + FRAME_LENGTH);
                    var moreBytes = bytes.Slice(i + FRAME_LENGTH, bytes.Length);

                    var isCorrect = checkCRC(frameBytes);
                    var message = frameBytes.Slice(2, FRAME_LENGTH - 1);

                    frameInterceptor?.Apply(message, isCorrect);

                    await Task.Delay(1);
                    return await processAsync(moreBytes);
                }
            }
            return bytes;
        }

        private bool checkCRC(byte[] bytes)
        {
            var length = bytes.Length;
            return ByteUtils.CRC(bytes.Take(length - 1).ToArray()).Equals(bytes[length - 1]);
        }

        ~FrameService()
        {
            cancellationToken.Cancel();
        }
    }
}
