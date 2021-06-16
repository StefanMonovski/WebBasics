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
    class PageController : HtmlController
    {
        public IHttpResponse Page(IHttpRequest request)
        {
            return View();
        }
    }
}
