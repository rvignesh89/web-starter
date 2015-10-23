using Moq;
using NUnit.Framework;

namespace web_starter.tests
{
    [TestFixture]
    public class AppStarterTests
    {
        [Test]
        public void Test_CanAddProgInstance()
        {
            var instance = new Mock<IStartable>();
            var starter = new AppStarter();
            starter.Instance.Add(instance.Object);
            Assert.That(starter.Instance[0],Is.EqualTo(instance.Object));
        }

        [Test]
        public void Test_CanAddMultipleInstances()
        {
            var instance1 = new Mock<IStartable>();
            var instance2 = new Mock<IStartable>();
            
            var starter = new AppStarter();
            starter.Instance.Add(instance1.Object);
            starter.Instance.Add(instance2.Object);

            Assert.That(starter.Instance[0], Is.EqualTo(instance1.Object));
            Assert.That(starter.Instance[1], Is.EqualTo(instance2.Object));
        }
    }
}