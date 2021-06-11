using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SIS.WebServer.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionDefaultMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(BadRequestExceptionDefaultMessage)
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
