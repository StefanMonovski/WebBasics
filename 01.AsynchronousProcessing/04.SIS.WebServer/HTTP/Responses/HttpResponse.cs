using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Extensions;
using _04.SIS.WebServer.HTTP.Globals;
using _04.SIS.WebServer.HTTP.Headers;
using _04.SIS.WebServer.HTTP.Headers.Interfaces;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            Headers = new HttpHeaderCollection();
            Content = Array.Empty<byte>();
        }

        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            StatusCode = statusCode;
        }

        public string Version { get => Constants.HttpDefaultVersion; }
        
        public HttpResponseStatusCode StatusCode { get; set; }
        
        public IHttpHeaderCollection Headers { get; }
        
        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            byte[] bytesResponse = Encoding.UTF8.GetBytes(ToString());
            byte[] bytesContent = Content;

            byte[] bytes = bytesResponse.Concat(bytesContent).ToArray();
            return bytes;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Constants.HttpDefaultVersion} {StatusCode.GetStatusLine()}");
            sb.Append(Constants.HttpNewLine);
            sb.Append(Headers);
            sb.Append(Constants.HttpNewLine);
            sb.Append(Constants.HttpNewLine);
            return sb.ToString();
        }
    }
}
