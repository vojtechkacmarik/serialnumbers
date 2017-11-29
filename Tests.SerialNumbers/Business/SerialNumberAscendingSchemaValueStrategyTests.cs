using System;
using NUnit.Framework;
using SerialNumbers.Business;
using SerialNumbers.Entity;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberAscendingSchemaValueStrategyTests : TestsBase<SerialNumberAscendingSchemaValueStrategy>
    {
        [Test]
        public void IsSuitable_WhenSchemaDefinitionIsNull_ShouldThrowException()
        {
            var schemaValue = Create<SchemaValue>();
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.IsSuitable(null, schemaValue));
        }

        [Test]
        public void IsSuitable_WhenStrategyIsSuitable_ShouldReturnTrue()
        {
            var schemaValue = Create<SchemaValue>();
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Increment = 1;
            var actual = SystemUnderTest.IsSuitable(schemaDefinition, schemaValue);
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSuitable_WhenCurrentSchemaValueIsNull_ShouldReturnFalse()
        {
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Increment = 1;
            var actual = SystemUnderTest.IsSuitable(schemaDefinition, null);
            Assert.IsFalse(actual);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void IsSuitable_WhenSchemaDefinitionIncrementIsZeroOrNegative_ShouldReturnFalse(int increment)
        {
            var schemaValue = Create<SchemaValue>();
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Increment = increment;
            var actual = SystemUnderTest.IsSuitable(schemaDefinition, schemaValue);
            Assert.IsFalse(actual);
        }

        [Test]
        public void GetNextValue_WhenSchemaDefinitionIsNull_ShouldThrowException()
        {
            var schemaValue = Create<SchemaValue>();
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.GetNextValue(null, schemaValue));
        }

        [Test]
        public void GetNextValue_WhenCurrentSchemaValueIsNull_ShouldThrowException()
        {
            var schemaDefinition = Create<SchemaDefinition>();
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.GetNextValue(schemaDefinition, null));
        }

        [TestCase(1)]
        [TestCase(4)]
        public void GetNextValue_WhenEverythingIsCorrect_ShouldReturnNextValueAsExpected(int increment)
        {
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Increment = increment;
            var schemaValue = Create<SchemaValue>();
            schemaValue.Value = Random<int>();
            var actual = SystemUnderTest.GetNextValue(schemaDefinition, schemaValue);
            var expected = schemaValue.Value + schemaDefinition.Increment;
            Assert.AreEqual(expected, actual);
        }
    }
}