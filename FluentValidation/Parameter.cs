using System;

namespace Yelware.Utilities.Validation
{
    /// <summary>Base interface for a parameter with validation.</summary>
    internal class Parameter<T>: IParameter<T>
    {
        /// <summary>The name of the parameter to be validated.</sumamary>
        public string Name { get; private set; }

        /// <summary>The value that is validated.</summary>
        public T Value { get; }

        /// <summary>A function to validate that the parameter matches a condition.</summary>
        /// <param name="verifyFunc">The predicate condition.</param>
        /// <param name="violationMessage">The message to pass to the exception constructor when condition is false.</param>
        /// <remarks>This function will simply raise an EInvalidArgumentException when <see cref="predicate"> returns false.
        /// To use it call Validate.Parameter<int>(i, nameof(i)).Is((val) => val == 10, $"Expected {nameof(i)} == 10. Was {i}");
        /// <remarks>
        public IParameter<T> Is(Predicate<T> verifyFunc, string violationMessage)
        {
            return verifyFunc(Value) 
                ? this 
                : throw new ArgumentException(violationMessage);
        }

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
        internal Parameter(T value)
        {
            this.Value = value;
            Named(nameof(value));
        }

        /// <summary>
        /// Constructs a new instance of the Parameter class with the specified value and name..
        /// </summary>
        /// <param name="value">The value of the parameter to validate.</param>
        /// <param name="name">The name of the parameter to validate.</param>
        internal Parameter(T value, string name)
        {
            this.Value = value;
            Named(name);
        }
    }
}