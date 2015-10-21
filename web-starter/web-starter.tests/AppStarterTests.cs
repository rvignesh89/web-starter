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
            starter.Instance = instance.Object;
            Assert.That(starter.Instance,Is.EqualTo(instance.Object));
        }
    }
}