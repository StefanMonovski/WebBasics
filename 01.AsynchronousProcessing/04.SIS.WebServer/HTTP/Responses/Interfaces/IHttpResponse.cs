using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Headers;
using _04.SIS.WebServer.HTTP.Headers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Responses.Interfaces
{
    public interface IHttpResponse
    {
        public string Version { get; }

        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}
