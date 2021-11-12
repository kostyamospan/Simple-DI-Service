using System;
using System.Threading;

namespace SimpleDI.Exceptions
{
    public class DiException : Exception
    {
        protected DiException(string message)
            : base($"{nameof(DiException)}. {message}")
        {
        }
    }
}