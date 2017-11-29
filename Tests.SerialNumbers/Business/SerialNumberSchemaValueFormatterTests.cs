using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SerialNumbers.Business;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberSchemaValueFormatterTests : TestsBase<SerialNumberSchemaValueFormatter>
    {
        private Mock<ISerialNumberSchemaValueValidator> _serialNumberSchemaValueValidatorMock;

        [SetUp]
        public new void Setup()
        {
            _serialNumberSchemaValueValidatorMock = GetMock<ISerialNumberSchemaValueValidator>();
        }

        [TestCase("one-parameter {0} {1}", "param1")]
        [TestCase("many-parameters {0} {1} {2}", "param1", "param2")]
        [TestCase("many-parameters-with-format {0} {1} {2} {3:0000}", "param1", "param2", "param3")]
        [TestCase("many-parameters-with-different-format {0} {1} {2} {3:###}", "param1", "param2", "param3")]
        [TestCase("many-repeatedly-parameters {0} {1} {1}", "param1")]
        [TestCase("many-repeatedly-parameters-with-different-format {0} {1} {1:00}", "param1")]
        public void Format_WhenIsValid_ShouldReturnExpected(string mask, params string[] args)
        {
            _serialNumberSchemaValueValidatorMock
                .Setup(x => x.Validate(mask, args))
                .Callback(
                    (string maskInner, string[] argsInner) =>
                    {
                    });
            var value = Random<int>();
            var actual = SystemUnderTest.Format(mask, value, args);
            var parameters = BuildParameters(value, args);
            var expected = string.Format(mask, parameters);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Format_ShouldCallValidateFromSerialNumberSchemaValueValidatorOnce()
        {
            var mask = Random<string>();
            var value = Random<int>();
            SystemUnderTest.Format(mask, value, "p1", "p2");

            _serialNumberSchemaValueValidatorMock.Verify(x => x.Validate(It.IsAny<string>(), It.IsAny<string[]>()), Times.Once());
        }

        private static object[] BuildParameters(int value, IEnumerable<string> args)
        {
            return args != null ? new object[] { value }.Concat(args).ToArray() : new object[] { value }.ToArray();
        }
    }
}