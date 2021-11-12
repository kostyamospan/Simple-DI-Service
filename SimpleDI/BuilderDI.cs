using System;
using System.Collections;
using System.Collections.Generic;
using SimpleDI.Abstract;
using SimpleDI.Exceptions;

namespace SimpleDI
{
    public class BuilderDI : IBuilderDi
    {
        private readonly Dictionary<Type, object> _registeredServices = new();

        public T GetRegisteredService<T>() where T : new()
        {
            if (!IsRegistered<T>())
                throw new UnregisteredServiceException(typeof(T));
            return (T) _registeredServices[typeof(T)];
        }

        public IBuilderDi RegisterService<T>() where T : new()
        {
            if (IsRegistered<T>())
                throw new DuplicatedServicesException(typeof(T));
            return RegisterService<T>(_=> new T());
        }

        public IBuilderDi RegisterService<T>(Func<T, T> factory) where T : new()
        {
            if (IsRegistered<T>())
                throw new DuplicatedServicesException(typeof(T));
            _registeredServices[typeof(T)] = factory(new T());
            return this;
        }

        public bool IsRegistered<T>()
            => _registeredServices.ContainsKey(typeof(T));
    }
}