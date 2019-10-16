using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallPark3.Objects
{
    [Serializable]
    public class Player: ICloneable
    {
        public String Name { get; set; }
        public Double OPS { get; set; }
        public int OnBase { get; set; }
        public String Team { get; set; }
        public Double AVG { get; set; }

        public bool RemoveBatter { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
