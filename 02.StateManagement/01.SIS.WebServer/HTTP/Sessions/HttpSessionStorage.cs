using _01.SIS.WebServer.HTTP.Sessions.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Sessions
{
    public class HttpSessionStorage
    {
        private static readonly ConcurrentDictionary<string, HttpSession> sessions = new();

        public static HttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, new HttpSession(id));
        }
    }
}
