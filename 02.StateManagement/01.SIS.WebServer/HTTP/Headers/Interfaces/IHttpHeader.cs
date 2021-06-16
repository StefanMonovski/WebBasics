using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Headers.Interfaces
{
    public interface IHttpHeader
    {
        public string Key { get; }

        public string Value { get; }
    }
}
