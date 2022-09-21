using System;
using Xunit;
using FluentAssertions;

using Yelware.Utilities.Validation;

namespace Yelware.Utilities.FluentValidationTests
{
    public class ValidateParameter_For_Nulls
    {
        [Fact]
        public void Validate_Parameter_Does_Not_Throw_ArgumentNullException_For_Null_Name()
        {
            Object obj = null;
            Action act = () => Validate.Parameter(obj, null);
            act.Should().NotThrow();
        }

        [Fact]
        public void Is_With_Not_Null_Test_Throws_ArgumentException()
        {
            Object obj = null;
            Assert.Throws<ArgumentException>(
                () => Validate.Parameter(obj, nameof(obj))
                    .Match((p) => p != null, $"{nameof(obj)} must not be null")
            );
        }

        [Fact]
        public void IsNotNull_Extension_For_Null_String_Throws_ArgumentException()
        {
            string value = null;
            Assert.Throws<ArgumentException>(
                () => Validate.Parameter(value).Named(nameof(value))
                    .IsNotNull()
            );
        }

        [Fact]
        public void IsNotNull_Extension_For_Nullable_Int_Throws_ArgumentException()
        {
            int? value = null;
            Assert.Throws<ArgumentException>(
                () => Validate.Parameter(value).Named(nameof(value))
                    .IsNotNull()
            );
        }

        [Fact]
        public void Type_Extension_Works()
        {
            int value = 100;
            var p = value.Must();
            Assert.True(p is IParameter<int>);
            p.Name.Should().Be("value");
        }

        [Fact]
        public void Must_Does_Not_Throw_For_Null_Object()
        {
            Object obj = null;

            Action act = () => obj.Must();
            act.Should().NotThrow();
        }

        [Fact]
        public void Must_With_Null_Test_Throws_ArgumentException()
        {
            Object obj = null;

            Action act = () => obj.Must().NotBeNull();
            act.Should().Throw<ArgumentException>().WithMessage($"Value must not be null (Parameter 'obj')");
        }
    }
}
