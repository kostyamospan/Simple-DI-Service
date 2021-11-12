using System;

namespace SimpleDI.Exceptions
{
    public class UnregisteredServiceException : DiException
    {
        public UnregisteredServiceException(Type serviceType)
            : base($"Type {nameof(serviceType)} is not registered in DI container")
        {
        }
    }
}