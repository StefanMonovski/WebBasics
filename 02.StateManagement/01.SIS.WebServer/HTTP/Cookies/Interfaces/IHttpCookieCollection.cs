using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Cookies.Interfaces
{
    public interface IHttpCookieCollection
    {
        public int Count { get; }

        public void Add(IHttpCookie cookie);

        public bool ContainsCookie(string key);

        public IHttpCookie GetCookie(string key);
    }
}
