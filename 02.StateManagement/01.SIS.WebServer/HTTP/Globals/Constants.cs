using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Globals
{
    public class Constants
    {
        public const string localIpAddressString = "127.0.0.1";

        public const int localPort = 80;

        public const string HttpNewLine = "\r\n";

        public const string HttpDefaultVersion = "HTTP/1.1";

        public const string HttpPathRegexPattern = @"/{1}.*";        

        public const string HttpContentTypeHeaderKey = "Content-Type";

        public const string HttpContentTypeHeaderHtml = "text/html; charset=utf-8";

        public const string HttpContentTypeHeaderText = "text/plain; charset=utf-8";

        public const string HttpRequestCookieHeaderKey = "Cookie";

        public const string HttpResponseCookieHeaderKey = "Set-Cookie: ";

        public const int HttpCookieDefaultExpirationDays = 3;

        public const string HttpCookieDefaultPath = "/";

        public const string HttpSessionCookieKey = "SIS_ID";
    }
}
