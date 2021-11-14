using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleDI.Abstract;
using SimpleDI.Exceptions;
using SimpleDI.Reflection;

namespace SimpleDI
{
    public class BuilderDI : IBuilderDi
    {
        private readonly HashSet<Type> _registeredServices = new();

        public T GetRegisteredService<T>() where T : class
            => (T) GetRegisteredServiceImpl(typeof(T), new HashSet<Type>());

        public IBuilderDi RegisterService<T>() where T : class
        {
            RegisterServiceImpl(typeof(T));
            return this;
        }

        public bool IsRegistered<T>()
            => _registeredServices.Contains(typeof(T));
        public bool IsRegistered(Type type)
            => _registeredServices.Contains(type);
        

        /// <param name="type">Type to resolve</param>
        /// <param name="resolvedTypes">stores all resolved dependencies.
        /// Needed to prevent circulating dependencies
        /// </param>
        private object GetRegisteredServiceImpl(Type type, HashSet<Type> resolvedTypes)
        {
            if (!IsRegistered(type))
                throw new UnregisteredServiceException(type);

            var constructor
                = ArgumentsParser.GetConstructor(type);

            var resolvedTypeArguments = new List<object>();

            foreach (var argument in constructor.Arguments)
            {
                var resolvedType = GetRegisteredServiceImpl(argument.Type, resolvedTypes);

                if (resolvedType is null) throw new ArgumentNullException(nameof(resolvedType));
                if (resolvedTypes.Contains(argument.Type)) throw new CircularDependencyException(argument.Type);

                resolvedTypes.Add(argument.Type);
                resolvedTypeArguments.Add(resolvedType);
            }

            var reflectionConstructorInfo = type.GetConstructor(
                constructor.Arguments
                    .Select(v => v.Type)
                    .ToArray());

            return reflectionConstructorInfo?.Invoke(resolvedTypeArguments.ToArray()) ??
                   throw new ArgumentNullException(nameof(reflectionConstructorInfo));
        }

        private void RegisterServiceImpl(Type type)
        {
            if (IsRegistered(type))
                throw new DuplicatedServicesException(type);
            _registeredServices.Add(type);
        }
    }
}