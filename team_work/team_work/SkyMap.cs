﻿using System;
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
    /// <summary>
    /// Класс для карты звездного неба
    /// </summary>
    class SkyMap
    {
        private string[] ServerGroup = null;
        private string[] ServerStar = null;
        /// <summary>
        /// Конструктор
        /// </summary>
        public SkyMap()
        {
            this.ServerGroup = new string[]{
            "http://server1.sky-map.org/getstars.jsp?", 
            "http://server2.sky-map.org/getstars.jsp?", 
            "http://server3.sky-map.org/getstars.jsp?"};

            this.ServerStar = new string[]{
            "http://server1.sky-map.org/search?",
            "http://server2.sky-map.org/search?",
            "http://server3.sky-map.org/search?"};
        }

        /// <summary>
        /// Определение десятичного разделителя
        /// </summary>
        public static NumberFormatInfo NFI()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return nfi;
        }

        /// <summary>
        /// Получение списка объектов для заданных параметров
        /// </summary>
        /// <param name="sp">Объект</param>
        /// <param name="angle">Угол</param>
        /// <param name="maxStars">Максимальное количество</param>
        /// <returns></returns>
        public List<SpacePoint> Query(SpacePoint sp, float angle, int maxStars)
        {
            for (int i = 0; i < ServerGroup.Length; i++)
            {
                try
                {
                    string request = CreateRequest(sp, angle, maxStars, ServerGroup[i]);
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

        /// <summary>
        /// Поиск звезды по названию
        /// </summary>
        /// <param name="starName">Название звезды</param>
        public Star Query(String starName)
        {
            for (int i = 0; i < ServerGroup.Length; i++)
            {
                try
                {
                    string request = CreateRequest(starName, ServerStar[i]);
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
        /// <summary>
        /// Формирование запроса на поиск информации о звезде по ее названию
        /// </summary>
        /// <param name="starName">Название звезды</param>
        /// <param name="Server">Сервер</param>
        private static string CreateRequest(String starName, string Server)
        {
            string request = Server;
            request += "star=" + starName;
            return request;
        }
        /// <summary>
        /// Формирование запроса на поиск информации о звезде по заданным параметрам
        /// </summary>
        /// <param name="sp">Объект</param>
        /// <param name="angle">Угол</param>
        /// <param name="maxStars">Максимальное количество звезд</param>
        /// <param name="Server">Сервер</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение xml от сервера
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <returns></returns>
        private static XmlDocument MakeRequest(string request)
        {
            HttpWebRequest httpRequest = WebRequest.Create(request) as HttpWebRequest;
            HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(httpResponse.GetResponseStream());
            return xmlDoc;
        }

        /// <summary>
        /// Получение информации по выбранной звезде
        /// </summary>
        /// <param name="xml">Xml для запроса</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение списка звезд по заданным параметрам
        /// </summary>
        /// <param name="xml">Xml для запроса</param>
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
