using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallPark3.Objects
{
    [Serializable]
    public class Team
    {
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string City { get; set; }
        public double OPS { get; set; }
        public double ABHR { get; set; }
        public double TeamRBI { get; set; }
        public double OBAHome { get; set; } //also known as AVG in Pitching stats
        public double OBAAway { get; set; }
        public double FP { get; set; }
        public double DefEff { get; set; } //also know as DER

        public Team() { }
    }
}
