using System;
namespace Yelware.Utilities.Validation
{
    public static class Validate
    {
        public static IParameter<T> Parameter<T>(T value, string name) {
            return new Parameter<T>(name, value);
        }
    }
}