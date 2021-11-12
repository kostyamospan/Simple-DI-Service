using System;

namespace SimpleDI.Exceptions
{
    public class TooManyConstructorsException : DiException
    {
        public TooManyConstructorsException(Type type)
            : base($"Type {nameof(type)} has more than 1 constructor")
        {
        }
    }
}