using System;
using log4net;
using Moq;
using NUnit.Framework;

namespace web_starter.tests
{
    [TestFixture]
    public class AppStarterTests
    {
        private Mock<IStartable> _Subscriber;
        private Mock<IStartable> _Subscriber2;
        private Mock<IStartable> _FailingSubscriber;
        private AppStarter _AppStarter;

        [Test]
        public void Test_StartAll_Calls_SubscribedInstance()
        {
            _AppStarter.RegisterWith(_Subscriber.Object);
            _AppStarter.StartAll();

            _Subscriber.Verify(x => x.Start(), Times.Once);
        }

        [Test]
        public void Test_StartAll_Calls_All_SubscribedInstance()
        {
            _AppStarter.RegisterWith(_Subscriber.Object);
            _AppStarter.RegisterWith(_Subscriber2.Object);

            _AppStarter.StartAll();

            _Subscriber.Verify(x => x.Start(), Times.Once);
            _Subscriber2.Verify(x => x.Start(), Times.Once);
        }

        [Test]
        public void Test_StartAll_CallsSubscribersOnExceptionIfAnyExceptionIsThrown()
        {
            _AppStarter.RegisterWith(_FailingSubscriber.Object);

            _AppStarter.StartAll();

            _FailingSubscriber.Verify(x=>x.OnException(),Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            _AppStarter = new AppStarter();

            _Subscriber = new Mock<IStartable>();
            _Subscriber.Setup(x => x.Start());

            _Subscriber2 = new Mock<IStartable>();
            _Subscriber2.Setup(x => x.Start());

            _FailingSubscriber = new Mock<IStartable>();
            _FailingSubscriber.Setup(x => x.Start()).Throws<ArgumentNullException>();
            _FailingSubscriber.Setup(x => x.GetName()).Returns("Test");
        }
    }
}