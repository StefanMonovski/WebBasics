using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Headers.Interfaces;
using _01.SIS.WebServer.HTTP.Sessions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Requests.Interfaces
{
    public interface IHttpRequest
    {
        public HttpRequestMethod Method { get; }

        public string Path { get; }

        public string Version { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public string Body { get; }

        public IHttpSession Session { get; set; }
    }
}
