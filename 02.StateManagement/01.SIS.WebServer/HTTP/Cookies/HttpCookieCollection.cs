using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Globals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Cookies
{
    class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, IHttpCookie> cookies;

        public HttpCookieCollection()
        {
            cookies = new Dictionary<string, IHttpCookie>();
        }

        public int Count { get => cookies.Count; }

        public void Add(IHttpCookie cookie)
        {
            cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return cookies.ContainsKey(key);
        }

        public IHttpCookie GetCookie(string key)
        {
            return cookies[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var cookie in cookies)
            {
                sb.Append(Constants.HttpResponseCookieHeaderKey + cookie.Value + Constants.HttpNewLine);
            }
            return sb.ToString();
        }
    }
}
