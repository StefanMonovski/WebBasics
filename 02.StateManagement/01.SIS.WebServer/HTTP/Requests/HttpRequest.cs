using _01.SIS.WebServer.HTTP.Cookies;
using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Exceptions;
using _01.SIS.WebServer.HTTP.Globals;
using _01.SIS.WebServer.HTTP.Headers;
using _01.SIS.WebServer.HTTP.Headers.Interfaces;
using _01.SIS.WebServer.HTTP.Requests.Interfaces;
using _01.SIS.WebServer.HTTP.Sessions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.SIS.WebServer.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new HttpHeaderCollection();
            Cookies = new HttpCookieCollection();

            ParseRequest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Path { get; private set; }

        public string Version { get; private set; }
       
        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }
        
        public string Body { get; private set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string request)
        {
            List<string> splitRequest = request.Split(Constants.HttpNewLine, StringSplitOptions.None).ToList();

            List<string> splitStartLine = splitRequest[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            ParseStartLine(splitStartLine);

            List<string> splitHeaders = SplitHeaders(splitRequest);
            ParseHeaders(splitHeaders);

            List<string> splitCookies = SplitCookies();
            ParseCookies(splitCookies);

            string body = GetBody(splitRequest);
            Body = body;
        }

        private void ParseStartLine(List<string> splitStartLineString)
        {
            if (!IsValidStartLine(splitStartLineString))
            {
                throw new BadRequestException();
            }

            string methodString = splitStartLineString[0];
            HttpRequestMethod method = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), methodString, true);

            Method = method;
            Path = splitStartLineString[1];
            Version = splitStartLineString[2];
        }

        private static bool IsValidStartLine(List<string> splitStartLineString)
        {
            if (Enum.TryParse(splitStartLineString[0], true, out HttpRequestMethod result) &&
                Regex.IsMatch(splitStartLineString[1], Constants.HttpPathRegexPattern) &&
                splitStartLineString[2] == Constants.HttpDefaultVersion)
            {
                return true;
            }
            return false;
        }

        private static List<string> SplitHeaders(List<string> splitRequest)
        {
            List<string> splitHeaders = new();
            for (int i = 1; i < splitRequest.Count; i++)
            {
                if (string.IsNullOrEmpty(splitRequest[i]))
                {
                    break;
                }
                splitHeaders.Add(splitRequest[i]);
            }
            return splitHeaders;
        }

        private void ParseHeaders(List<string> splitHeaders)
        {
            foreach (var header in splitHeaders)
            {
                string[] splitHeader = header.Split(": ", 2).ToArray();
                string key = splitHeader[0];
                string value = splitHeader[1];
                Headers.Add(new HttpHeader(key, value));
            }
        }

        private List<string> SplitCookies()
        {
            List<string> splitCookies = new();
            if (Headers.ContainsHeader(Constants.HttpRequestCookieHeaderKey))
            {
                string cookies = Headers.GetHeader(Constants.HttpRequestCookieHeaderKey).Value;
                splitCookies.AddRange(cookies.Split("; ").ToArray());
            }
            return splitCookies;
        }

        private void ParseCookies(List<string> splitCookies)
        {
            foreach (var cookie in splitCookies)
            {
                string[] splitCookie = cookie.Split("=");
                string key = splitCookie[0];
                string value = splitCookie[1];
                Cookies.Add(new HttpCookie(key, value));
            }
        }


        private string GetBody(List<string> splitRequestString)
        {
            int bodyPosition = 2 + Headers.Count;
            if (splitRequestString.Count == bodyPosition)
            {
                return splitRequestString[bodyPosition];
            }
            return null;
        }
    }
}
