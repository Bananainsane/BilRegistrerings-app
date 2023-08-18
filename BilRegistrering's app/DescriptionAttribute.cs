
using System;

namespace BilRegistrering_s_app
{
    
    // Custom attribute to provide a description to fields, especially useful for enums.
    
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        // The description associated with the field.
        public string Description { get; }

        
        // Initializes a new instance of the DescriptionAttribute class with the specified description.
        
        // <param name="description">The description to associate with the field.</param>
        public DescriptionAttribute(string description) => Description = description;
    }
}
