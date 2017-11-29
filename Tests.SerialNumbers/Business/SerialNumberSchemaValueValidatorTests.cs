using System;
using NUnit.Framework;
using SerialNumbers.Business;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberSchemaValueValidatorTests : TestsBase<SerialNumberSchemaValueValidator>
    {
        [Test]
        public void Validate_WhenArgumentIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.Validate(null));
        }

        [TestCase("non-parameters")]
        [TestCase("missing-parameter {0}", "param1")]
        [TestCase("unnecessary-parameter {0} {1} {2}", "param1")]
        public void Validate_WhenMaskIsInvalid_ShouldThrowException(string mask, params string[] args)
        {
            Assert.Throws<InvalidOperationException>(() => SystemUnderTest.Validate(mask, args));
        }

        [Test]
        public void Validate_WhenMaskContainsOnlyOneParameter_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => SystemUnderTest.Validate("default-parameter {0}", null));
        }

        [TestCase("one-parameter {0} {1}", "param1")]
        [TestCase("many-parameters {0} {1} {2}", "param1", "param2")]
        [TestCase("many-parameters-with-format {0} {1} {2} {3:0000}", "param1", "param2", "param3")]
        [TestCase("many-parameters-with-different-format {0} {1} {2} {3:###}", "param1", "param2", "param3")]
        [TestCase("many-repeatedly-parameters {0} {1} {1}", "param1")]
        [TestCase("many-repeatedly-parameters-with-different-format {0} {1} {1:00}", "param1")]
        public void Validate_WhenMaskIsValid_ShouldNotThrowException(string mask, params string[] args)
        {
            Assert.DoesNotThrow(() => SystemUnderTest.Validate(mask, args));
        }
    }
}