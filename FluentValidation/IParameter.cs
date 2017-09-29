using System;

namespace Yelware.Utilities.Validation
{
    /// <summary>Base interface for a parameter with validation.</summary>
    public interface IParameter<T>
    {
        /// <summary>The name of the parameter to be validated.</sumamary>
        string Name { get; }

        /// <summary>The value that is validated.</summary>
        T Value { get; }

        /// <summary>A function to validate that the parameter matches a condition.</summary>
        /// <param name="verifyFunc">The predicate condition.</param>
        /// <param name="violationMessage">The message to pass to the exception constructor when condition is false.</param>
        /// <remarks>This function will simply raise an EInvalidArgumentException when <see cref="predicate"> returns false.
        /// To use it call Validate.Parameter<int>(i, nameof(i)).Is((val) => val == 10, $"Expected {nameof(i)} == 10. Was {i}");
        /// <remarks>
        IParameter<T> Is(Predicate<T> verifyFunc, string violationMessage);
    }
}