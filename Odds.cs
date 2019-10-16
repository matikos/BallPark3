using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallPark3
{
    public class Odds //league avg 8/15/19
    {
        public static readonly Double Ratio_Chance_Single = 0.6183;
        public static readonly Double Ratio_Chance_Double = 0.2029;
        public static readonly Double Ratio_Chance_Trible = 0.0183;
        public static readonly Double Ratio_Chance_Home = 0.1606;

        public static int Calculate(Random random, double DefEff)
        {
            Double x = random.NextDouble();

            if ((x -= (Ratio_Chance_Double * DefEff)) < 0)
            {
                return 2;
            }
            else if ((x -= (Ratio_Chance_Trible * DefEff)) < 0)
            {
                return 3;
            }
            else if ((x -= (Ratio_Chance_Home * DefEff)) < 0)
            {
                return 4;
            }
            else
            {
                return 1;
            }
        }
    }
}
