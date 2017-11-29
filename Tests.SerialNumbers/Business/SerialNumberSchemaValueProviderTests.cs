using System;
using System.Collections.Generic;
using NUnit.Framework;
using SerialNumbers.Business;
using SerialNumbers.Entity;

namespace Tests.SerialNumbers.Business
{
    [TestFixture]
    public class SerialNumberSchemaValueProviderTests : TestsBase<SerialNumberSchemaValueProvider>
    {
        [Test]
        public void Ctor_WhenArgumentIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var _ = new SerialNumberSchemaValueProvider(null);
            });
        }

        [Test]
        public void GetNextValue_WhenSchemaDefinitionIsNull_ShouldThrowException()
        {
            var initialSchemaValueStrategy = Create<SerialNumberInitialSchemaValueStrategy>();
            var systemUnderTest = new SerialNumberSchemaValueProvider(
                new List<ISerialNumberSchemaValueStrategy> { initialSchemaValueStrategy });
            var schemaValue = Create<SchemaValue>();
            Assert.Throws<ArgumentNullException>(() => systemUnderTest.GetNextValue(null, schemaValue));
        }

        [Test]
        public void GetNextValue_WhenNoStrategyIsSuitable_ShouldThrowException()
        {
            var initialSchemaValueStrategy = Create<SerialNumberInitialSchemaValueStrategy>();
            var systemUnderTest = new SerialNumberSchemaValueProvider(
                new List<ISerialNumberSchemaValueStrategy> { initialSchemaValueStrategy });
            var schemaDefinition = Create<SchemaDefinition>();
            var schemaValue = Create<SchemaValue>();
            Assert.Throws<InvalidOperationException>(() => systemUnderTest.GetNextValue(schemaDefinition, schemaValue));
        }

        [Test]
        public void GetNextValue_WhenManyStrategiesAreSuitable_ShouldThrowException()
        {
            var initialSchemaValueStrategy = Create<SerialNumberInitialSchemaValueStrategy>();
            var testSchemaValueStrategy = Create<TestSerialNumberInitialSchemaValueStrategy>();
            var systemUnderTest = new SerialNumberSchemaValueProvider(
                new List<ISerialNumberSchemaValueStrategy> { initialSchemaValueStrategy, testSchemaValueStrategy });
            var schemaDefinition = Create<SchemaDefinition>();
            Assert.Throws<InvalidOperationException>(() => systemUnderTest.GetNextValue(schemaDefinition, null));
        }

        [Test]
        public void GetNextValue_WhenStrategyIsResolved_ShouldReturnExpected()
        {
            var initialSchemaValueStrategy = Create<SerialNumberInitialSchemaValueStrategy>();
            var systemUnderTest = new SerialNumberSchemaValueProvider(
                new List<ISerialNumberSchemaValueStrategy> { initialSchemaValueStrategy });
            var seed = Random<int>();
            var schemaDefinition = Create<SchemaDefinition>();
            schemaDefinition.Seed = seed;
            var actual = systemUnderTest.GetNextValue(schemaDefinition, null);
            Assert.AreEqual(seed, actual);
        }

        public class TestSerialNumberInitialSchemaValueStrategy : ISerialNumberSchemaValueStrategy
        {
            public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
            {
                return currentSchemaValue == null;
            }

            public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
            {
                return 0;
            }
        }
    }
}