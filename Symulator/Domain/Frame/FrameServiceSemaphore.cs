using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Symulator.Domain.Frame
{
    public class FrameServiceSemaphore: IFrameService
    {
        private readonly int frameLength;
        private byte[] buffer = new byte[] { };
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        int indexAppend;
        int indexProcess = 0;

        //public event EventHandler PushFrame;

        public FrameServiceSemaphore(int frameLength)
        {
            this.frameLength = frameLength;
        }

        public void Append(byte[] rawFrame)
        {
            throw new NotImplementedException();
        }

        public async Task AppendAsync(byte[] bytes)
        {
            Console.Write($"append {indexAppend++}");
            Console.WriteLine($", data: {string.Join(" ", bytes)}\n");

            await semaphore.WaitAsync();
            try
            {
                buffer = await Task.Run(() => process(buffer.Concat(bytes).ToArray()));
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine($"End process");
            }
        }

        private byte[] process(byte[] bytes)
        {
            for (int i = 0, l = bytes.Count(); i < l; i++)
            {
                if (bytes.ElementAt(i).Equals(0xAA) && bytes.ElementAtOrDefault(i + 1).Equals(0x55))
                {
                    if (i + frameLength > l)
                    {
                        return bytes;
                    }

                    var frameBytes = bytes.Slice(i, i + frameLength);
                    var moreBytes = bytes.Slice(i + frameLength, bytes.Length);

                    Console.Write($"process {indexProcess++}, bytes: {bytes.Length}");
                    Console.WriteLine($", data: {string.Join(" ", frameBytes)}\n");

                    return process(moreBytes);
                }
            }

            return bytes;
        }

        public void Subscribe(Action<byte[], bool> action)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(ChannelWriter<byte[]> listener)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(IFrameInterceptor<byte[]> frameInterceptor)
        {
            throw new NotImplementedException();
        }
    }
}
