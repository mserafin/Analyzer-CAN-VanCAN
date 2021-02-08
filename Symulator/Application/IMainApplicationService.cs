using Symulator.Domain.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator.Application
{
    interface IMainApplicationService
    {
        event EventHandler<BindingList<ViewMessage>> OnMessageDataSource;

        void Init();

        void Append(byte[] rawFrames);

        Task AppendAsync(byte[] rawFrame);
    }
}
