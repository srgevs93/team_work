using team_work;
using NUnit.Framework;
using System.Xml;

namespace team_workTests
{
    [TestFixture]
    class StarTests
    {
        private SpacePoint x, y, z;
        [TestFixtureSetUp]
        public void Init()
        {
            x = new SpacePoint(1, "cat1", 0, 0, 42.42f);
            y = new SpacePoint(1, "cat1", 0, 0, 42.42f);
            z = new SpacePoint(1, "cat2", 0, 0, 666.13f);
        }

        [Test]
        public void TestComparingByName_Equal()
        {
            Assert.That(Star.compareByName(x, y) == 0);
        }

        [Test]
        public void TestComparingByName_NotEqual()
        {
            Assert.That(Star.compareByName(x, z) != 0);
        }

        [Test]
        public void TestComparingByMag_Equal()
        {
            Assert.That(Star.compareByMag(x, y) == 0);
        }

        [Test]
        public void TestComparingByMag_NotEqual()
        {
            Assert.That(Star.compareByMag(x, z) != 0);
        }
    }
}
