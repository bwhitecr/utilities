using System;

namespace Yelware.Utilities.Validation
{
    /// <summary>Base interface for a parameter with validation.</summary>
    public class Parameter<T>: IParameter<T>
    {
        /// <summary>The name of the parameter to be validated.</sumamary>
        public string Name { get; }

        /// <summary>The value that is validated.</summary>
        public T Value { get; }

        /// <summary>A function to validate that the parameter matches a condition.</summary>
        /// <param name="condition">The test condition.</param>
        /// <param name="violationMessage">The message to pass to the exception constructor when condition is false.</param>
        /// <remarks>This function will simply raise an EInvalidArgumentException when condition == false.
        /// To use it call Validate.Parameter<int>(i, nameof(i)).Is(i == 10, $"Expected {nameof(i)} == 10. Was {i}");
        /// <remarks>
        public IParameter<T> Is(bool condition, string violationMessage)
        {
            if (condition)
                return this;

            throw new EInvalidArgumentException(violationMessage);
        }

        public Parameter<T>(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}