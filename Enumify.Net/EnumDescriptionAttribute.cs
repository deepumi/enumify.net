using System;

namespace Enumify.Net
{
    /// <summary>
    /// Specifies a description for a Enum field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Get Enum description stored in this attribute.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes a new instance of the Enumify.Net.EnumDescriptionAttribute.
        /// </summary>
        /// <param name="description">The description text.</param>
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Returns whether the value of the given object is equal to the current Enumify.Net.EnumDescriptionAttribute.
        /// </summary>
        /// <param name="obj">Enum object to check the equality</param>
        /// <returns></returns>
        public override bool Equals(object obj) => obj is EnumDescriptionAttribute other && other.Description == Description;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Description?.GetHashCode() ?? 0;
    }
}