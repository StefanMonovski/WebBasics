using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Cookies
{
    public class HttpResponseCookie : HttpCookie, IHttpResponseCookie
    {
        public HttpResponseCookie(string key, string value)
            : base (key, value)
        {
            Path = Constants.HttpCookieDefaultPath;
            Expires = DateTime.UtcNow.AddDays(Constants.HttpCookieDefaultExpirationDays);
        }

        public string Domain { get; }
        
        public string Path { get; }
        
        public DateTime? Expires { get; private set; }
        
        public int? MaxAge { get; }
        
        public bool HttpOnly { get; }
        
        public bool Secure { get; }        

        public void Delete()
        {
            Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append(base.ToString());

            if (Expires.HasValue)
            {
                sb.Append($"; Expires={Expires.Value:R}");
            }
            else if (MaxAge.HasValue)
            {
                sb.Append($"; Max-Age={MaxAge.Value}");
            }

            if (!string.IsNullOrWhiteSpace(Domain))
            {
                sb.Append($"; Domain={Domain}");
            }
            if (!string.IsNullOrWhiteSpace(Path))
            {
                sb.Append($"; Path={Path}");
            }

            if (Secure)
            {
                sb.Append("; Secure");
            }
            if (HttpOnly)
            {
                sb.Append("; HttpOnly");
            }

            return sb.ToString();
        }
    }
}
