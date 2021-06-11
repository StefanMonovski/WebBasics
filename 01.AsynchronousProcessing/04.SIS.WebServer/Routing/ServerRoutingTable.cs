using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Requests.Interfaces;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using _04.SIS.WebServer.Routing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.Routing
{
    public class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> routingTable;

        public ServerRoutingTable()
        {
            routingTable = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            { 
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
            };
        }

        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            routingTable[method].Add(path, func);
        }

        public bool Contains(HttpRequestMethod method, string path)
        {
            return routingTable.ContainsKey(method) && routingTable[method].ContainsKey(path);
        }

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod method, string path)
        {
            return routingTable[method][path];
        }
    }
}
