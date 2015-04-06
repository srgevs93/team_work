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
    class Query
    {
        private const string Server = "http://server1.sky-map.org/getstars.jsp?";
        public static NumberFormatInfo NFI()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return nfi;
        }
        public static List<SpacePoint> QuerySkyMap(SpacePoint sp, float angle, int maxStars)
        {
            string request = CreateRequest(sp, angle, maxStars);
            XmlDocument response = MakeRequest(request);

            List<SpacePoint> list = Parse(response);
            return list;
        }
        private static string CreateRequest(SpacePoint sp, float angle, int maxStars)
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
            HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(httpResponse.GetResponseStream());
            return xmlDoc;
        }

        private static List<SpacePoint> Parse(XmlDocument xml)
        {
            List<SpacePoint> list = new List<SpacePoint>();
            //Create namespace manager
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
            XmlNodeList stars = xml.GetElementsByTagName("star");

            foreach(XmlElement star in stars)
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
