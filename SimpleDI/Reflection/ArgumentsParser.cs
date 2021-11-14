using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleDI.Exceptions;
using SimpleDI.Models;

namespace SimpleDI.Reflection
{
    public class ArgumentsParser
    {
        /// <summary>
        /// Gets all arguments of a constructor of a given type
        /// Requires type to have single constructor
        /// </summary>
        public static TypeConstructor GetConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            if (constructors.Length > 1) throw new TooManyConstructorsException(type);

            return new TypeConstructor()
            {
                Arguments = !constructors.Any()
                    ? Enumerable.Empty<FunctionArgument>()
                    : constructors
                        .First()
                        .GetParameters()
                        .Select(v =>
                            new FunctionArgument() {Name = v.Name, Type = v.ParameterType})
            };
        }
    }
}