using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Headers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Requests.Interfaces
{
    public interface IHttpRequest
    {
        public HttpRequestMethod Method { get; }

        public string Path { get; }

        public string Version { get; }

        public IHttpHeaderCollection Headers { get; }

        public string Body { get; }
    }
}
