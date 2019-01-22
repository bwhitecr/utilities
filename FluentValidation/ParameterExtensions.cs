using System;

namespace Yelware.Utilities.Validation
{
    public static class ParameterExtensions
    {
        public static IParameter<T> IsNotNull<T>(
            this IParameter<T> parameter) where T : class
        {
            return parameter.Is(value => !(value is null), $"{parameter.Name} must not be null");
        }

        public static IParameter<Nullable<T>> IsNotNull<T>(
             this IParameter<Nullable<T>> parameter) where T : struct
        {
            return parameter.Is(value => value.HasValue, $"{parameter.Name} must not be null");
        }
    }
}