using System;
using NUnit.Framework;
using SerialNumbers.Business;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberSchemaDefinitionValidatorTests : TestsBase<SerialNumberSchemaDefinitionValidator>
    {
        [Test]
        public void Validate_WhenMaskIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.Validate(null, Random<int>()));
        }

        [TestCase("")]
        [TestCase("not-valid")]
        [TestCase("not-valid {0")]
        [TestCase("not-valid 0")]
        [TestCase("not-valid 0}")]
        public void Validate_WhenMaskIsNotValid_ShouldThrowException(string mask)
        {
            Assert.Throws<InvalidOperationException>(() => SystemUnderTest.Validate(mask, Random<int>()));
        }

        [Test]
        public void Validate_WhenIncrementIsNotValid_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => SystemUnderTest.Validate("valid {0}", 0));
        }

        [TestCase("{0}", 1)]
        [TestCase("some test {0}", -1)]
        [TestCase("some {0} test", -10)]
        [TestCase("many params {0} separated {1:00}", 20)]
        public void Validate_WhenIsValid_ShouldNotThrowException(string mask, int increment)
        {
            Assert.DoesNotThrow(() => SystemUnderTest.Validate(mask, increment));
        }
    }
}