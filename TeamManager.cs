using System;
using System.Collections.Generic;
using System.Linq;


namespace BallPark3
{
    [Serializable]
    public class TeamManager
    {
        public List<Objects.Player> BattingOrder { get; set; }

        
        public TeamManager()
        {
            BattingOrder = new List<Objects.Player>();
        }

        public List<Objects.Team> Teams = new List<Objects.Team>();
       
        //assignment of players to their teams
        public static Objects.Team TeamSelection(List<Objects.Team> mlb, string choice)
        {
            if (mlb.Any(T => T.Abbrev.ToLower().Equals(choice.ToLower())))
            {
                return mlb.Where(T => T.Abbrev.ToLower().Equals(choice.ToLower())).SingleOrDefault();
            }
            else
            {
                return new Objects.Team();
            }
        }
    }
}