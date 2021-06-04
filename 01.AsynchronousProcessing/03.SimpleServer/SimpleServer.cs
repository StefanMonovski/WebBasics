using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03.SimpleServer
{
    public class SimpleServer
    {
        private readonly TcpListener listener;

        public SimpleServer(int port)
        {
            listener = new TcpListener(IPAddress.Loopback, port);
        }

        public async Task Run()
        {
            listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();
                HandleClient(client);
            }
        }

        private void HandleClient(TcpClient client)
        {
            var stream = client.GetStream();

            while (!stream.DataAvailable)
            {
                Thread.Sleep(1);
            }
            string request = string.Empty;
            while (stream.DataAvailable)
            {
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);
                request += Encoding.UTF8.GetString(buffer);
            }
            Console.WriteLine(request);

            var responseString = File.ReadAllText(@"Http\HttpResponse.txt");
            var responseBytes = Encoding.UTF8.GetBytes(responseString);
            stream.Write(responseBytes);
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}
