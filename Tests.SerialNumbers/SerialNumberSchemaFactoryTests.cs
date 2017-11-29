using System;
using NUnit.Framework;
using SerialNumbers;

namespace Tests.SerialNumbers
{
    [TestFixture]
    public class SerialNumberSchemaFactoryTests : TestsBase<SerialNumberSchemaFactory>
    {
        [Test]
        public void Create_ShouldReturnExpected()
        {
            var schema = Random<string>();
            var customer = Random<string>();
            var mask = Random<string>();
            var seed = Random<int>();
            var increment = Random<int>();
            var createdAt = Random<DateTime>();

            var schemaDefinitionMock = CreateMock<ISerialNumberSchemaDefinition>();
            schemaDefinitionMock.Setup(x => x.Mask).Returns(mask);
            schemaDefinitionMock.Setup(x => x.Seed).Returns(seed);
            schemaDefinitionMock.Setup(x => x.Increment).Returns(increment);
            schemaDefinitionMock.Setup(x => x.CreatedAt).Returns(createdAt);

            var serialNumberSchemaDefinitionFactoryMock = GetMock<ISerialNumberSchemaDefinitionFactory>();
            serialNumberSchemaDefinitionFactoryMock.Setup(x => x.Create(mask, seed, increment, createdAt)).Returns(schemaDefinitionMock.Object);

            var actual = SystemUnderTest.Create(schema, customer, mask, seed, increment, createdAt);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(schema, actual.Schema, $"The property {nameof(actual.Schema)} is not equal!");
                Assert.AreEqual(customer, actual.Customer, $"The property {nameof(actual.Customer)} is not equal!");
                Assert.AreEqual(mask, actual.SchemaDefinition.Mask, $"The property {nameof(actual.SchemaDefinition.Mask)} is not equal!");
                Assert.AreEqual(seed, actual.SchemaDefinition.Seed, $"The property {nameof(actual.SchemaDefinition.Seed)} is not equal!");
                Assert.AreEqual(increment, actual.SchemaDefinition.Increment, $"The property {nameof(actual.SchemaDefinition.Increment)} is not equal!");
                Assert.AreEqual(createdAt, actual.SchemaDefinition.CreatedAt, $"The property {nameof(actual.SchemaDefinition.CreatedAt)} is not equal!");
            });
        }
    }
}