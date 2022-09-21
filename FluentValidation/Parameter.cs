using System;
using System.Reflection;

namespace Yelware.Utilities.Validation
{
    /// <summary>Base interface for a parameter with validation.</summary>
    internal class Parameter<T>: IParameter<T>
    {
        /// <summary>The name of the parameter to be validated.</summary>
        public string Name { get; private set; }

        /// <summary>The value that is validated.</summary>
        public T Value { get; }

        /// <inheritdoc cref="IParameter{T}.Match"/>
        public IParameter<T> Match(Predicate<T> verifyFunc, string violationMessage) =>
            verifyFunc(Value) ? this : throw new ArgumentException(violationMessage, this.Name);

        /// <summary>
        /// Allows the parameter name to be specified.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>Returns the IParameter interface.</returns>
        public IParameter<T> Named(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            return this;
        }

        /// <summary>
        /// Constructs a new instance of the Parameter class with the specified value.
        /// </summary>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="name">The name of the parameter to validate.</param>
        public Parameter(T value, [System.Runtime.CompilerServices.CallerArgumentExpression("value")] string name = "")
        {
            this.Value = value;
            if (string.IsNullOrEmpty(name))
                Named(nameof(value));
            else
                Named(name);
        }
    }
}