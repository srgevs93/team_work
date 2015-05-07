using team_work;
using NUnit.Framework;
using System.Xml;
using System.Collections.Generic;

namespace team_workTests
{
    [TestFixture]
    public class SkyMapTests
    {
        private XmlDocument groupResponse, starResponse;
        private List<SpacePoint> group = new List<SpacePoint>();
        private Star star;

        [TestFixtureSetUp]
        public void Init()
        {
            groupResponse = new XmlDocument();
            groupResponse.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<response>
    <ra>0.0</ra>
    <de>0.0</de>
    <angle>120.0</angle>
    <max_stars>2</max_stars>
    <star id=""206"">
        <catId>α Aur</catId>
        <ra>5.2781667</ra>
        <de>45.998056</de>
        <mag>0.08</mag>
    </star>
    <star id=""209"">
        <catId>α Eri</catId>
        <ra>1.6285833</ra>
        <de>-57.236667</de>
        <mag>0.46</mag>
    </star>
    <msgs></msgs>
</response>");
            group.Add(new SpacePoint(206, "α Aur", 5.2781667, 45.998056, 0.08f));
            group.Add(new SpacePoint(209, "α Eri", 1.6285833, -57.236667, 0.46f));

            starResponse = new XmlDocument();
            starResponse.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-\""?>
<response>
    <request>α Aur </request>
    <status>0</status>
    <verbiage>OK</verbiage>
    <object id=""S206"">
        <type id=""1"">Star</type>
        <name>α Aur</name>
        <catId>α Aur</catId>
        <constellation id=""8"">Auriga</constellation>
        <ra unit=""hour"">5.2781667</ra>
        <de unit=""degree"">45.998056</de>
        <mag>0.08</mag>
    </object>
</response>
");
            star = new Star(group[0], new Constellation(8, "Auriga"));
        }

        [Test]
        public void TestParseGroup()
        {
            List<SpacePoint> lst = SkyMap.ParseGroup(groupResponse);

            Assert.That(true);
        }

        [Test]
        public void TestParseStar()
        {
            Star s = SkyMap.ParseStar(starResponse);

            Assert.That(true);
        }
    }
}
