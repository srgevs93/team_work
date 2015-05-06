using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_work
{
    /// <summary>
    /// Класс задает параметры для звездного объекта
    /// </summary>
    class SpacePoint
    {
        /// <summary>
        /// Конструктор
        /// <remarks>Используется для найденных объектов</remarks>
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="catID">Название в каталоге</param>
        /// <param name="ra">Прямое восхождение звезды</param>
        /// <param name="de">Склонение</param>
        /// <param name="mag">Звездная величина</param>
        public SpacePoint(int id, string catID, double ra, double de, float mag)
        {
            this.ID = id;
            this.CatID = catID;
            this.RA = ra;         
            this.DE = de;         
            this.Magnitude = mag; 
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <remarks>Используется для поиска объектов</remarks>
        /// <param name="ra">Прямое восхождение звезды</param>
        /// <param name="de">Склонение</param>
        /// <param name="mag">Звездная величина</param>
        public SpacePoint(double ra, double de, float mag)
        {
            this.RA = ra;
            this.DE = de;
            this.Magnitude = mag;
        }
        
        public readonly int ID;
        public readonly string CatID;
        public readonly double RA;
        public readonly double DE;
        public readonly float Magnitude;
    }

    /// <summary>
    /// Класс задает параметры для созвездия
    /// </summary>
    class Constellation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        public Constellation(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public readonly int ID;
        public readonly string Name;
    }

    /// <summary>
    /// Класс задает парметры для звезды
    /// </summary>
    class Star
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sp">Звездный объект</param>
        /// <param name="constellation">Созвездие, которому принадлежит звезда</param>
        public Star(SpacePoint sp, Constellation constellation)
        {
            this.SpcPoint = sp;
            this.Constellation = constellation;
        }

        public readonly SpacePoint SpcPoint;
        public readonly Constellation Constellation;
    }
}
