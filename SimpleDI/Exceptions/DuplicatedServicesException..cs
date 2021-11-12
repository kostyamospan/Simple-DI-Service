using System;

namespace SimpleDI.Exceptions
{
    public class DuplicatedServicesException : DiException
    {
        public DuplicatedServicesException(Type serviceType) 
            : base($"Service {nameof(serviceType)} is already registered in DI container")
        {
        }
    }
}