using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_work
{
    class SpacePoint
    {
        public SpacePoint(int id, string catID, double ra, double de, float mag)
        {
            this.ID = id;
            this.CatID = catID;
            this.RA = ra;         //прямое восхождение звезды
            this.DE = de;         //склонение
            this.Magnitude = mag; //звездная величина
        }

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

    class Constellation
    {
        public Constellation(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public readonly int ID;
        public readonly string Name;
    }

    class Star
    {
        public static int compareByName(SpacePoint x, SpacePoint y)
        {
            if ((x == null) || (y == null))
                return 0;
            return x.CatID.CompareTo(y.CatID);
        }

        public static int compareByMag(SpacePoint x, SpacePoint y)
        {
            if ((x == null) || (y == null))
                return 0;
            return x.Magnitude.CompareTo(y.Magnitude);
        }

        public Star(SpacePoint sp, Constellation constellation)
        {
            this.SpcPoint = sp;
            this.Constellation = constellation;
        }

        public readonly SpacePoint SpcPoint;
        public readonly Constellation Constellation;
    }
}
