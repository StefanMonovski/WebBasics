using _01.SIS.WebServer.HTTP.Cookies;
using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Headers;
using _01.SIS.WebServer.HTTP.Headers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Responses.Interfaces
{
    public interface IHttpResponse
    {
        public string Version { get; }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header);

        public void AddCookie(HttpCookie cookie);

        public byte[] GetBytes();
    }
}
