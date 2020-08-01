using System;
using System.Net;

namespace CopaMundoFilmes.Domain
{
    public class DominioException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public DominioException(string message, HttpStatusCode statusCode) : this(message)
        {
            HttpStatusCode = statusCode;
        }

        public DominioException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
        }
    }
}
