using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.Globalization;

namespace team_work
{
    class SkyMap
    {
        private const int MaxServerNumber = 8;
        private string getServerGroup (int num)
        {
            return "http://server" + num.ToString() + ".sky-map.org/getstars.jsp?";
        }
        private string getServerStar (int num)
        {
            return "http://server" + num.ToString() + ".sky-map.org/search?"; 
        }

        public static NumberFormatInfo NFI()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return nfi;
        }

        public List<SpacePoint> Query(SpacePoint sp, float angle, int maxStars)
        {
            for (int i = 0; i < MaxServerNumber; i++)
            {
                try
                {
                    string request = CreateRequest(sp, angle, maxStars, getServerGroup(i));
                    XmlDocument response = MakeRequest(request);
                    List<SpacePoint> list = ParseGroup(response);
                    return list;
                }
                catch (System.Net.WebException e)
                {

                }
            }
            return null;
        }

        public Star Query(String starName)
        {
            for (int i = 0; i < MaxServerNumber; i++)
            {
                try
                {
                    string request = CreateRequest(starName, getServerStar(i));
                    XmlDocument response = MakeRequest(request);

                    Star star = ParseStar(response);
                    return star;
                }
                catch (System.Net.WebException e)
                {

                }
            }
            return null;
        }
        private static string CreateRequest(String starName, string Server)
        {
            string request = Server;
            request += "star=" + starName;
            return request;
        }
        private static string CreateRequest(SpacePoint sp, float angle, int maxStars, string Server)
        {
            string request = Server;
            request += "ra=" + sp.RA + "&";
            request += "de=" + sp.DE + "&";
            request += "max_vmag=" + sp.Magnitude + "&";
            request += "angle=" + angle + "&";
            request += "max_stars=" + maxStars;
            return request;
        }

        private static XmlDocument MakeRequest(string request)
        {
            HttpWebRequest httpRequest = WebRequest.Create(request) as HttpWebRequest;
            httpRequest.Timeout = 10000;
            HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(httpResponse.GetResponseStream());
            return xmlDoc;
        }

        private static Star ParseStar(XmlDocument xml)
        {
            XmlElement star = (XmlElement)xml.GetElementsByTagName("object")[0];
            //int id = int.Parse((star.Attributes["id"].Value));
            string catID = star.GetElementsByTagName("catId")[0].InnerText;

            XmlElement constellation = (XmlElement)star.GetElementsByTagName("constellation")[0];
            int constellationID = int.Parse(constellation.Attributes["id"].Value);
            string constellationName = constellation.InnerText;

            double ra = double.Parse(star.GetElementsByTagName("ra")[0].InnerText, NFI());
            double de = double.Parse(star.GetElementsByTagName("de")[0].InnerText, NFI());
            float mag = float.Parse(star.GetElementsByTagName("mag")[0].InnerText, NFI());
            return new Star(new SpacePoint(0, catID, ra, de, mag), new Constellation(constellationID, constellationName));
        }

        private static List<SpacePoint> ParseGroup(XmlDocument xml)
        {
            List<SpacePoint> list = new List<SpacePoint>();
            XmlNodeList stars = xml.GetElementsByTagName("star");

            foreach (XmlElement star in stars)
            {
                int id = int.Parse((star.Attributes["id"].Value));
                string catID = star.GetElementsByTagName("catId")[0].InnerText;
                double ra = double.Parse(star.GetElementsByTagName("ra")[0].InnerText, NFI());
                double de = double.Parse(star.GetElementsByTagName("de")[0].InnerText, NFI());
                float mag = float.Parse(star.GetElementsByTagName("mag")[0].InnerText, NFI());
                list.Add(new SpacePoint(id, catID, ra, de, mag));
            }
            return list;
        }
    }
}
