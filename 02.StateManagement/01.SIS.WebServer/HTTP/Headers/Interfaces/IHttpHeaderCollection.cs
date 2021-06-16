using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Headers.Interfaces
{
    public interface IHttpHeaderCollection
    {
        public int Count { get; }

        public void Add(HttpHeader header);

        public bool ContainsHeader(string key);

        public HttpHeader GetHeader(string key);
    }
}
