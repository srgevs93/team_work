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
            this.RA = ra;
            this.DE = de;
            this.Magnitude = mag;
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
}
