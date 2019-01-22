using System;

namespace Yelware.Utilities.Validation
{
    /// <summary>Base interface for a parameter with validation.</summary>
    public interface IParameter<T>
    {
        /// <summary>The name of the parameter to be validated.</summary>
        string Name { get; }

        /// <summary>The value that is validated.</summary>
        T Value { get; }

        /// <summary>A function to validate that the parameter matches a condition.</summary>
        /// <param name="verifyFunc">The predicate condition.</param>
        /// <param name="violationMessage">The message to pass to the exception constructor when condition is false.</param>
        /// <returns>Returns the IParameter interface.</returns>
        /// <remarks>This function will simply raise an ArgumentException when <see cref="predicate"/> returns false.
        /// To use it call Validate.Parameter&lt;int&gt;(i, nameof(i)).Is((val) =&gt; val == 10, $"Expected {nameof(i)} == 10. Was {i}");
        /// </remarks>
        IParameter<T> Is(Predicate<T> verifyFunc, string violationMessage);

        /// <summary>
        /// Allows the parameter name to be specified.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>Returns the IParameter interface.</returns>
        IParameter<T> Named(string name);
    }
}