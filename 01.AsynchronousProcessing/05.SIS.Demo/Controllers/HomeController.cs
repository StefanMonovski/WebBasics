using _04.SIS.WebServer.HTTP.Requests.Interfaces;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SIS.Demo.Controllers
{
    public class HomeController : HtmlController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            return View();
        }
    }
}
