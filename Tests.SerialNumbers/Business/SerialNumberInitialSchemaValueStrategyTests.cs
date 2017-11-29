using System;
using NUnit.Framework;
using SerialNumbers.Business;
using SerialNumbers.Entity;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberInitialSchemaValueStrategyTests : TestsBase<SerialNumberInitialSchemaValueStrategy>
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
            var schemaDefinition = Create<SchemaDefinition>();
            var actual = SystemUnderTest.IsSuitable(schemaDefinition, null);
            Assert.IsTrue(actual);
        }

        [Test]
        public void GetNextValue_WhenSchemaDefinitionIsNull_ShouldThrowException()
        {
            var schemaValue = Create<SchemaValue>();
            Assert.Throws<ArgumentNullException>(() => SystemUnderTest.GetNextValue(null, schemaValue));
        }

        [Test]
        public void GetNextValue_WhenEverythingIsCorrect_ShouldReturnNextValueAsExpected()
        {
            var seed = Random<int>();
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Seed = seed;
            var actual = SystemUnderTest.GetNextValue(schemaDefinition, null);
            Assert.AreEqual(seed, actual);
        }
    }
}