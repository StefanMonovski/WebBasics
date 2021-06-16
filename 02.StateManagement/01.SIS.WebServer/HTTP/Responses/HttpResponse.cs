using _01.SIS.WebServer.HTTP.Cookies;
using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Extensions;
using _01.SIS.WebServer.HTTP.Globals;
using _01.SIS.WebServer.HTTP.Headers;
using _01.SIS.WebServer.HTTP.Headers.Interfaces;
using _01.SIS.WebServer.HTTP.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            Headers = new HttpHeaderCollection();
            Cookies = new HttpCookieCollection();
            Content = Array.Empty<byte>();
        }

        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            StatusCode = statusCode;
        }

        public string Version { get => Constants.HttpDefaultVersion; }
        
        public HttpResponseStatusCode StatusCode { get; set; }
        
        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            Cookies.Add(cookie);
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
            StringBuilder sb = new();
            sb.Append($"{Constants.HttpDefaultVersion} {StatusCode.GetStatusLine()}");
            sb.Append(Constants.HttpNewLine);
            sb.Append(Headers.ToString());
            sb.Append(Constants.HttpNewLine);
            if (Cookies.Count > 0)
            {
                sb.Append(Cookies.ToString());
                sb.Append(Constants.HttpNewLine);
            }
            sb.Append(Constants.HttpNewLine);
            return sb.ToString();
        }
    }
}
