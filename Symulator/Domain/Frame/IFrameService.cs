using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Symulator.Domain.Frame
{
    interface IFrameService
    {
        void Append(byte[] rawFrame);
        Task AppendAsync(byte[] rawFrame);
        void Subscribe(IFrameInterceptor<byte[]> frameInterceptor);
    }
}
