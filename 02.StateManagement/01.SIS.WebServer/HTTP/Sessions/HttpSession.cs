using _01.SIS.WebServer.HTTP.Sessions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> parameters;

        public HttpSession(string id)
        {
            Id = id;
            parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public object GetParameter(string name)
        {
            return parameters[name];
        }

        public bool ContainsParameter(string name)
        {
            return parameters.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            parameters.Add(name, parameter);
        }

        public void ClearParameters()
        {
            parameters.Clear();
        }
    }
}
