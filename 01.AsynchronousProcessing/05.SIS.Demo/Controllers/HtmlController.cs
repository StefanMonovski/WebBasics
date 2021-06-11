using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using _04.SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.SIS.Demo.Controllers
{
    public class HtmlController
    {
        public IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string path = "Views" + "\\" + controllerName + "\\" + viewName + ".html";
            string viewContent = File.ReadAllText(path);

            return new HtmlResult(viewContent, HttpResponseStatusCode.Ok);
        }
    }
}
