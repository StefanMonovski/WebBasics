using _04.SIS.WebServer.Routing.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace _04.SIS.WebServer
{
    public class Server
    {
        private const string localIpAddressString = "127.0.0.1";

        private const int localPort = 80;

        private readonly IPAddress ipAddress;

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IServerRoutingTable serverRoutingTable;

        private bool isRunning;

        public Server(IServerRoutingTable serverRoutingTable)
        {
            ipAddress = IPAddress.Parse(localIpAddressString);
            port = localPort;
            listener = new TcpListener(ipAddress, port);
            this.serverRoutingTable = serverRoutingTable;
        }

        public Server(string ipAddressString, int port, IServerRoutingTable serverRoutingTable)
        {
            ipAddress = IPAddress.Parse(ipAddressString);
            this.port = port;
            listener = new TcpListener(ipAddress, this.port);
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task RunAsync()
        {
            listener.Start();
            isRunning = true;

            Console.WriteLine($"Server started at http://{ipAddress}:{port}");

            while (isRunning)
            {
                Console.WriteLine("Waiting for client...");
                Socket client = await listener.AcceptSocketAsync();

                #pragma warning disable CS4014
                Task.Run(() => Listen(client));
                #pragma warning restore CS4014
            }
        }

        public async Task Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, serverRoutingTable);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}
