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
        private Mock<ILog> _Logger;

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
        public void Test_StartAll_LogsTheInfo_IfAnySubscriberReturnsFalse()
        {
            _AppStarter.RegisterWith(_FailingSubscriber.Object);

            _AppStarter.StartAll();

            _Logger.Verify(log => log.ErrorFormat("Subscriber {0} failed to start", "Test"), Times.Once());
        }

        [SetUp]
        public void Setup()
        {
            _Logger = new Mock<ILog>();
            _Logger.Setup(log => log.ErrorFormat(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            _AppStarter = new AppStarter(_Logger.Object);

            _Subscriber = new Mock<IStartable>();
            _Subscriber.Setup(x => x.Start()).Returns(true);

            _Subscriber2 = new Mock<IStartable>();
            _Subscriber2.Setup(x => x.Start()).Returns(true);

            _FailingSubscriber = new Mock<IStartable>();
            _FailingSubscriber.Setup(x => x.Start()).Returns(false);
            _FailingSubscriber.Setup(x => x.GetName()).Returns("Test");
        }
    }
}