
using System;
using System.Linq;
using System.Reflection;

namespace BilRegistrering_s_app
{

    // Provides extension methods for the Enum type.
    public static class EnumExtensions
    {
        
        // Retrieves a custom attribute associated with a specific enum value.
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<TAttribute>();
        }
    }
}
