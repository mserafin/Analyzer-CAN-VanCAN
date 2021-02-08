using System;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Symulator.Domain.Message
{
    public class MessageNetworkService : IMessageService
    {
        private Uri uri;
        public MessageNetworkService(Uri uri)
        {
            this.uri = uri;
        }

        public async void ConnectAsync()
        {
            //var client = new TcpClient();
            //client.Connect("localhost", 8080);
            //for (int i = 0; i < 100; i++)
            //{
            //    await Task.Delay(i * 100);
            //    var b = Encoding.UTF8.GetBytes(i.ToString() + '\n');
            //    await client.GetStream().WriteAsync(b, 0, b.Length);
            //    _ = Task.Run(async () =>
            //    {
            //        var b = new byte[1024];
            //        var n = await client.GetStream().ReadAsync(b, 0, b.Length);
            //        Console.WriteLine(Encoding.UTF8.GetString(b, 0, n));
            //    });
            //}
        }

        public void Append(byte[] frame)
        {
            var message = Message.Builder().WithFrame(frame).Build();

            Console.WriteLine($"Message network: {message.CanId}, {message.DataLength}, {string.Join(" ", message.Data)}, {message.ASCII}\n");
        }
    }
}
