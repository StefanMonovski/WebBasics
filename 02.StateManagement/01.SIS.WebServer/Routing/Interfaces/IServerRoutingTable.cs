using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Requests.Interfaces;
using _01.SIS.WebServer.HTTP.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.Routing.Interfaces
{
    public interface IServerRoutingTable
    {
        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);

        public bool Contains(HttpRequestMethod method, string path);

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod method, string path);
    }
}
