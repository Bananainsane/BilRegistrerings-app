using System;

namespace BilRegistrering_s_app
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description) => Description = description;
    }
}
