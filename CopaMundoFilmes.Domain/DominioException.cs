using System;

namespace CopaMundoFilmes.Domain
{
    public class DominioException : Exception
    {
        public DominioException(string message) : base(message)
        {
        }
    }
}
