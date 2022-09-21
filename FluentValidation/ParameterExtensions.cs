using System;

namespace Yelware.Utilities.Validation
{
    public static class ParameterExtensions
    {
        public static IParameter<T> IsNotNull<T>(this IParameter<T> parameter) where T : class =>
            parameter.Match(value => !(value is null), "Value must not be null");

        public static IParameter<T> NotBeNull<T>(this IParameter<T> parameter) where T : class => IsNotNull<T>(parameter);

        public static IParameter<Nullable<T>> IsNotNull<T>(this IParameter<Nullable<T>> parameter) where T : struct =>
            parameter.Match(value => value.HasValue, "Value must not be null");

        public static IParameter<Nullable<T>> NotBeNull<T>(this IParameter<Nullable<T>> parameter) where T : struct => IsNotNull<T>(parameter);

        public static IParameter<T> Must<T>(this T value, [System.Runtime.CompilerServices.CallerArgumentExpression("value")] string memberName = "") =>
            Validate.Parameter(value, memberName);
    }
}