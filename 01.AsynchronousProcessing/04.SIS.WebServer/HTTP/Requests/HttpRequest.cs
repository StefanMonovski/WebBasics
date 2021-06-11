using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Exceptions;
using _04.SIS.WebServer.HTTP.Globals;
using _04.SIS.WebServer.HTTP.Headers;
using _04.SIS.WebServer.HTTP.Headers.Interfaces;
using _04.SIS.WebServer.HTTP.Requests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new HttpHeaderCollection();

            ParseRequest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Path { get; private set; }

        public string Version { get; private set; }
       
        public IHttpHeaderCollection Headers { get; }
        
        public string Body { get; private set; }

        private void ParseRequest(string requestString)
        {
            List<string> splitRequestString = requestString.Split(Constants.HttpNewLine, StringSplitOptions.None).ToList();

            List<string> splitStartLineString = splitRequestString[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            ParseStartLine(splitStartLineString);

            List<string> splitHeadersStringList = SplitHeadersString(splitRequestString);
            ParseHeaders(splitHeadersStringList);

            string bodyString = GetBodyString(splitRequestString);
            Body = bodyString;
        }

        private void ParseStartLine(List<string> splitStartLineString)
        {
            if (!IsValidStartLine(splitStartLineString))
            {
                throw new BadRequestException();
            }

            string methodString = splitStartLineString[0];
            var method = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), methodString, true);

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

        private List<string> SplitHeadersString(List<string> splitRequestString)
        {
            List<string> splitHeadersStringList = new List<string>();
            for (int i = 1; i < splitRequestString.Count; i++)
            {
                if (string.IsNullOrEmpty(splitRequestString[i]))
                {
                    break;
                }
                splitHeadersStringList.Add(splitRequestString[i]);
            }
            return splitHeadersStringList;
        }

        private void ParseHeaders(List<string> splitHeadersStringList)
        {
            foreach (var headerString in splitHeadersStringList)
            {
                string[] splitHeaderString = headerString.Split(": ", 2).ToArray();
                string key = splitHeaderString[0];
                string value = splitHeaderString[1];
                Headers.Add(new HttpHeader(key, value));
            }
        }


        private string GetBodyString(List<string> splitRequestString)
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
