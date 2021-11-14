using System;

namespace SimpleDI.Exceptions
{
    public class CircularDependencyException : DiException
    {
        public CircularDependencyException(Type type) 
            : base($"Circular dependencies are unacceptable. Type: {nameof(type)}")
        {
        }
    }
}