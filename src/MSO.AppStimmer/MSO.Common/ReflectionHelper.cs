using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MSO.Common
{
    public static class ReflectionHelper
    {
        /// <summary>
        ///     Creates an instance of an object with a variable number of constructor paramers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterArray"></param>
        /// <returns>An instance of the specified type</returns>
        public static T CreateInstance<T>(params object[] parameterArray)
        {
            var instance = (T)Activator.CreateInstance(typeof(T), parameterArray);
            return instance;
        }

        /// <summary>
        ///     Tries to find a matching constructor for a given type and a variable number of parameters
        /// </summary>
        /// <param name="type">The type a constructor has to be found for</param>
        /// <param name="givenParameters">The parameters for the constructor</param>
        /// <returns></returns>
        public static ConstructorInfo GetConstructor(Type type, params object[] givenParameters)
        {
            ConstructorInfo constructor;

            // If there are parameters specified, try to find a constructor with matching parameter count and types
            if (givenParameters != null && givenParameters.Length > 0)
            {
                constructor = type.GetTypeInfo().DeclaredConstructors.SingleOrDefault(c =>
                {
                    var constructorParameters = c.GetParameters();
                    var result = HasConstructorMatchingParameters(givenParameters, constructorParameters);

                    return result;
                });
            }
            // If there are no parameters specified, try to find a parameterless constructor
            else
            {
                constructor = type.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(c => !c.GetParameters().Any());
            }

            return constructor;
        }

        /// <summary>
        ///     Compare a List of parameters types with the parameter types of a constructor.
        /// </summary>
        /// <param name="givenParameters"></param>
        /// <param name="constructorParameters"></param>
        /// <returns>True, if all the parameter types match. Otherwise false.</returns>
        private static bool HasConstructorMatchingParameters(IReadOnlyList<object> givenParameters,
            IReadOnlyList<ParameterInfo> constructorParameters)
        {
            var givenParametersCount = givenParameters.Count;

            // If the parameter count doesn't match, there cannot be a match of the parameter types lists.
            var equalParameterCount = constructorParameters.Count() == givenParametersCount;
            if (!equalParameterCount)
                return false;

            // Compare each parameter type of the given and the actual constructor parameters
            for (var i = givenParametersCount - 1; i >= 0; i--)
            {
                var parameterTypeMatch = constructorParameters[i].ParameterType
                    == givenParameters[i].GetType();

                if (!parameterTypeMatch)
                    return false;
            }

            return true;
        }
    }
}
