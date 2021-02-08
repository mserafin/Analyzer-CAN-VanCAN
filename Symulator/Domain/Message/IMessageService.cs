using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Symulator.Domain.Message
{
    public interface IMessageService
    {
        void Append(byte[] frame);
    }
}
