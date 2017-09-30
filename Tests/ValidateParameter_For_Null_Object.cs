using System;
using Xunit;

using Yelware.Utilities.Validation;

namespace Yelware.Utilities.FluentValidationTests
{
    public class ValidateParameter_For_Null_Object
    {
        [Fact]
        public void Validate_Parameter_Throws_ArgumentNullException_For_Null_Name()
        {
            Object obj = null;
            Assert.Throws<ArgumentNullException>(
                () => Validate.Parameter(obj, null)
            );
        }

        [Fact]
        public void Is_With_Not_Null_Test_Throws_ArgumentException()
        {
            Object obj = null;
            Assert.Throws<ArgumentException>(
                () => Validate.Parameter(obj, nameof(obj))
                    .Is((p) => p != null, $"{nameof(obj)} must not be null")
            );
        }
    }
}
