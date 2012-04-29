using System;
using System.Collections.Generic;
using System.Linq;

// Adds an extension methods to collections to get a random element
// Code from: http://nickstips.wordpress.com/2010/08/28/c-extension-method-get-a-random-element-from-a-collection/
namespace MoveIt.Helpers
{
    public static class Extensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> list)
        {
            // If there are no elements in the collection, return the default value of T
            if (list.Count() == 0)
                return default(T);

            // A  better random then the .NET one
            int hashCode = Math.Abs(Guid.NewGuid().GetHashCode());
            return list.ElementAt(hashCode % list.Count());
        }
    }
}