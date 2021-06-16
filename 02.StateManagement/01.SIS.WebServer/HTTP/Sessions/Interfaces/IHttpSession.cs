using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Sessions.Interfaces
{
    public interface IHttpSession
    {
        public string Id { get; }

        public object GetParameter(string name);

        public bool ContainsParameter(string name);

        public void AddParameter(string name, object parameter);

        public void ClearParameters();
    }
}
