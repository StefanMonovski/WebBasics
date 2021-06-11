using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Headers.Interfaces
{
    public interface IHttpHeaderCollection
    {
        int Count { get; }

        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
