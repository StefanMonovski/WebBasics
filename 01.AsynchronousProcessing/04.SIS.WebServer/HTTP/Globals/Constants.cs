using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Globals
{
    public class Constants
    {
        public const string HttpNewLine = "\r\n";

        public const string HttpDefaultVersion = "HTTP/1.1";

        public const string HttpPathRegexPattern = @"/{1}.*";        

        public const string HttpContentTypeHeaderKey = "Content-Type";

        public const string HttpContentTypeHeaderHtml = "text/html; charset=utf-8";

        public const string HttpContentTypeHeaderText = "text/plain; charset=utf-8";
    }
}
