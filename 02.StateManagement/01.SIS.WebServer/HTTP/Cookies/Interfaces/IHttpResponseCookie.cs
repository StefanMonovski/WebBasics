using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Cookies.Interfaces
{
    public interface IHttpResponseCookie
    {
        public string Domain { get; }

        public string Path { get; }

        public DateTime? Expires { get; }

        public int? MaxAge { get; }
        
        public bool HttpOnly { get; }

        public bool Secure { get; }

        public void Delete();
    }
}
