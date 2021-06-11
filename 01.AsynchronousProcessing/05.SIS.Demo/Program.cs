using _04.SIS.WebServer;
using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.Routing;
using _04.SIS.WebServer.Routing.Interfaces;
using _05.SIS.Demo.Controllers;
using System.Threading.Tasks;
using System;

namespace _05.SIS.Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Home(request));

            Server server = new Server(serverRoutingTable);
            await server.RunAsync();
        }
    }
}
