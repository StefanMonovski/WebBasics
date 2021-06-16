using _01.SIS.WebServer.HTTP.Cookies;
using _01.SIS.WebServer.HTTP.Cookies.Interfaces;
using _01.SIS.WebServer.HTTP.Enums;
using _01.SIS.WebServer.HTTP.Exceptions;
using _01.SIS.WebServer.HTTP.Globals;
using _01.SIS.WebServer.HTTP.Requests;
using _01.SIS.WebServer.HTTP.Requests.Interfaces;
using _01.SIS.WebServer.HTTP.Responses.Interfaces;
using _01.SIS.WebServer.HTTP.Sessions;
using _01.SIS.WebServer.Results;
using _01.SIS.WebServer.Routing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01.SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            string sessionId = null;
            IHttpResponse response = null;           

            try
            {
                IHttpRequest request = await ReadRequestAsync();

                if (request != null)
                {
                    Console.WriteLine($"Processing: {request.Method} {request.Path}...");

                    sessionId = SetRequestSession(request);
                    response = GetResponse(request);
                }
            }
            catch (BadRequestException e)
            {
                response = new TextResult(e.Message, HttpResponseStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                response = new TextResult(e.Message, HttpResponseStatusCode.InternalServerError);
            }

            SetResponseSession(response, sessionId);
            await ReturnResponse(response);

            client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            StringBuilder sb = new();
            ArraySegment<byte> buffer = new(new byte[1024]);

            while (true)
            {
                int bytesToRead = await client.ReceiveAsync(buffer.Array, SocketFlags.None);
                if (bytesToRead == 0)
                {
                    break;
                }

                string bytesString = Encoding.UTF8.GetString(buffer.Array, 0, bytesToRead);
                sb.Append(bytesString);

                if (bytesToRead < 1023)
                {
                    break;
                }
            }

            if (sb.Length == 0)
            {
                return null;
            }

            return new HttpRequest(sb.ToString());
        }

        private static string SetRequestSession(IHttpRequest request)
        {
            string sessionId;

            if (request.Cookies.ContainsCookie(Constants.HttpSessionCookieKey))
            {
                IHttpCookie cookie = request.Cookies.GetCookie(Constants.HttpSessionCookieKey);
                sessionId = cookie.Value;
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private IHttpResponse GetResponse(IHttpRequest request)
        {
            if (!serverRoutingTable.Contains(request.Method, request.Path))
            {
                return new TextResult($"Route with method {request.Method} and path \"{request.Path}\" not found.", HttpResponseStatusCode.NotFound);
            }

            return serverRoutingTable.Get(request.Method, request.Path).Invoke(request);
        }

        private static void SetResponseSession(IHttpResponse response, string sessionId)
        {
            if (sessionId != null)
            {
                response.AddCookie(new HttpCookie(Constants.HttpSessionCookieKey, sessionId));
            }
        }

        private async Task ReturnResponse(IHttpResponse response)
        {
            byte[] bytes = response.GetBytes();
            await client.SendAsync(bytes, SocketFlags.None);
        }
    }
}
