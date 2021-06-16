using _01.SIS.WebServer.HTTP.Globals;
using _01.SIS.WebServer.HTTP.Headers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            headers = new Dictionary<string, HttpHeader>();
        }

        public int Count { get => headers.Count; }

        public void Add(HttpHeader header)
        {
            headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            return headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            return headers[key];
        }

        public override string ToString()
        {
            return string.Join(Constants.HttpNewLine, headers.Values.Select(x => x.ToString()));
        }
    }
}
