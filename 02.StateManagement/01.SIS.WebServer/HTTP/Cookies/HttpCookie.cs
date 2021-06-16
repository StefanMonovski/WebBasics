using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Cookies
{
    public class HttpCookie : IHttpCookie
    {
        public HttpCookie(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{Key}={Value}";
        }
    }
}
