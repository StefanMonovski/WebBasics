using System;
using System.Threading.Tasks;

namespace _03.SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter local port number:");
            int port = int.Parse(Console.ReadLine());

            var server = new SimpleServer(port);
            Task task = server.Run();

            string input;
            if ((input = Console.ReadLine()) == "exit")
            {
                server.Stop();
            }
        }
    }
}
 