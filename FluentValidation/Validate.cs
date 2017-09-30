using System;
namespace Yelware.Utilities.Validation
{
    /// <summary>
    /// Static class to begin validation of parameters.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Constructs a new instance of the Fluent parameter validation interface for the specified value.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>Returns an IParameter interface.</returns>
        public static IParameter<T> Parameter<T>(T value) {
            return new Parameter<T>(value);
        }

        /// <summary>
        /// Constructs a new instance of the Fluent parameter validation interface for the specified value and name.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="name">The name of the paremter to validate.</param>
        /// <returns>Returns an IParameter interface.</returns>
        public static IParameter<T> Parameter<T>(T value, string name) {
            return new Parameter<T>(value, name);
        }
    }
}