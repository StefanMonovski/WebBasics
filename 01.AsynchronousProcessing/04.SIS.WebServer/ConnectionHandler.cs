using _04.SIS.WebServer.HTTP.Enums;
using _04.SIS.WebServer.HTTP.Exceptions;
using _04.SIS.WebServer.HTTP.Requests;
using _04.SIS.WebServer.HTTP.Requests.Interfaces;
using _04.SIS.WebServer.HTTP.Responses;
using _04.SIS.WebServer.HTTP.Responses.Interfaces;
using _04.SIS.WebServer.Results;
using _04.SIS.WebServer.Routing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer
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
            IHttpResponse response = null;

            try
            {
                IHttpRequest request = await ReadRequestAsync();

                if (request != null)
                {
                    Console.WriteLine($"Processing: {request.Method} {request.Path}...");
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

            await ReturnResponse(response);
            client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            StringBuilder sb = new StringBuilder();
            var buffer = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int bytesToRead = await client.ReceiveAsync(buffer.Array, SocketFlags.None);
                if (bytesToRead == 0)
                {
                    break;
                }

                var bytesString = Encoding.UTF8.GetString(buffer.Array, 0, bytesToRead);
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

        private IHttpResponse GetResponse(IHttpRequest request)
        {
            if (!serverRoutingTable.Contains(request.Method, request.Path))
            {
                return new TextResult($"Route with method {request.Method} and path \"{request.Path}\" not found.", HttpResponseStatusCode.NotFound);
            }

            return serverRoutingTable.Get(request.Method, request.Path).Invoke(request);
        }

        private async Task ReturnResponse(IHttpResponse response)
        {
            byte[] bytes = response.GetBytes();
            await client.SendAsync(bytes, SocketFlags.None);
        }
    }
}
