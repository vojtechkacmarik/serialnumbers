using System;
using NUnit.Framework;
using SerialNumbers;

namespace Tests.SerialNumbers
{
    [TestFixture]
    public class SerialNumberSchemaDefinitionFactoryTests : TestsBase<SerialNumberSchemaDefinitionFactory>
    {
        [Test]
        public void Create_ShouldReturnExpected()
        {
            var mask = Random<string>();
            var seed = Random<int>();
            var increment = Random<int>();
            var createdAt = Random<DateTime>();

            var actual = SystemUnderTest.Create(mask, seed, increment, createdAt);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(mask, actual.Mask, $"The property {nameof(actual.Mask)} is not equal!");
                Assert.AreEqual(seed, actual.Seed, $"The property {nameof(actual.Seed)} is not equal!");
                Assert.AreEqual(increment, actual.Increment, $"The property {nameof(actual.Increment)} is not equal!");
                Assert.AreEqual(createdAt, actual.CreatedAt, $"The property {nameof(actual.CreatedAt)} is not equal!");
            });
        }
    }
}