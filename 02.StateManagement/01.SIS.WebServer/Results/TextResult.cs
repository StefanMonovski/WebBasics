using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Globals;
using _01.SIS.WebServer.HTTP.Headers;
using _01.SIS.WebServer.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.Results
{
    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode statusCode) : base(statusCode)
        {
            Headers.Add(new HttpHeader(Constants.HttpContentTypeHeaderKey, Constants.HttpContentTypeHeaderText));
            Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
