using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Requests.Interfaces;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.Routing.Interfaces
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);

        bool Contains(HttpRequestMethod method, string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod method, string path);
    }
}
