using _01.SIS.WebServer.HTTP.Requests.Interfaces;
using _01.SIS.WebServer.HTTP.Responses.Interfaces;
using _02.SIS.Demo.Controllers.BaseControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SIS.Demo.Controllers
{
    public class HomeController : HtmlController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            return View();
        }
    }
}
