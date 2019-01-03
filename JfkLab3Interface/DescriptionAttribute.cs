using System;

namespace JfkLab3Interface
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
