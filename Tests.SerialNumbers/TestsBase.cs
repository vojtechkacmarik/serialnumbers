using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Tests.SerialNumbers
{
    [TestFixture]
    public abstract class TestsBase<TSystemUnderTest> where TSystemUnderTest : class
    {
        protected IFixture Fixture { get; private set; }
        protected AutoMocker Mocker { get; private set; }

        protected TSystemUnderTest SystemUnderTest => Mocker.CreateInstance<TSystemUnderTest>();

        [SetUp]
        public void Setup()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Mocker = new AutoMocker();
        }

        protected Mock<T> GetMock<T>() where T : class
            => Mocker.GetMock<T>();

        protected Mock<T> CreateMock<T>() where T : class
            => new Mock<T>();

        protected T Create<T>() where T : class
            => Mocker.CreateInstance<T>();

        protected T Random<T>()
            => Fixture.Create<T>();

        protected IEnumerable<T> RandomMany<T>(int count = 3)
            => Fixture.CreateMany<T>(count);
    }
}