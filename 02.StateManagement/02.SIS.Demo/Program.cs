using _01.SIS.WebServer;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.Routing;
using _01.SIS.WebServer.Routing.Interfaces;
using _02.SIS.Demo.Controllers;
using System.Threading.Tasks;
using System;

namespace _02.SIS.Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Home(request));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/Page", request => new PageController().Page(request));

            Server server = new(serverRoutingTable);
            await server.RunAsync();
        }
    }
}
