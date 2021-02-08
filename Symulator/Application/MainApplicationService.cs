using Symulator.Domain.Frame;
using Symulator.Domain.Message;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace Symulator.Application
{
    public class MainApplicationService : IMainApplicationService
    {
        public event EventHandler<BindingList<ViewMessage>> OnMessageDataSource;
        private readonly IFrameService frameService = new FrameService();

        public MainApplicationService() { }

        public void Init()
        {
            var storageService = new MessageStorageService("can-dump.csv"); //Path.GetPathRoot()

            // FrameChannelInterceptor vs FrameActionInterceptor
            var frameInterceptor = new FrameActionInterceptor();

            var sss = new MessageNetworkService(new Uri("ws://localhost:8080"));
            sss.ConnectAsync();

            frameInterceptor.Subscribe(new MessagePresenterService(source => toPresenter(source)));
            frameInterceptor.Subscribe(storageService);
            frameInterceptor.Subscribe(sss);

            frameService.Subscribe(frameInterceptor);

            _ = Task.Delay(10000).ContinueWith(async (it) => await storageService.ReadFile());
        }

        public void Append(byte[] rawFrames)
        {
            frameService.Append(rawFrames);
        }

        public async Task AppendAsync(byte[] rawFrames)
        {
            await frameService.AppendAsync(rawFrames);
        }

        private void toPresenter(BindingList<ViewMessage> source)
        {
            OnMessageDataSource?.Invoke(this, source);
        }
    }
}
