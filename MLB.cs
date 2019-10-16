using System;
using System.Collections.Generic;
using System.Linq;

namespace BallPark3
{
    public class MLB
    {
        public List<Objects.Team> Teams = new List<Objects.Team>()
        {
            //Stats ESPN as of 8/28/19
            new Objects.Team() { Name = "Angels", Abbrev = "LAA", City = "Los Angeles", OPS = 0.775, ABHR = 23.5, TeamRBI = 4.87, OBAHome = 0.253, OBAAway =0.258, FP = 0.983, DefEff = 0.689 },          //1
            new Objects.Team() { Name = "Diamondbacks", Abbrev = "ARI", City = "Arizona", OPS = 0.770, ABHR = 25.4, TeamRBI = 4.89, OBAHome = 0.256, OBAAway =0.253, FP = 0.986, DefEff = 0.688 },        //2
            new Objects.Team() { Name = "Braves", Abbrev = "ATL", City = "Atlanta", OPS = 0.797, ABHR = 22.3, TeamRBI = 5.17, OBAHome = 0.264, OBAAway =0.255, FP = 0.987, DefEff = 0.681 },              //3
            new Objects.Team() { Name = "Orioles", Abbrev = "BAL", City = "Baltimore", OPS = 0.711, ABHR = 27.4, TeamRBI = 4.14, OBAHome = 0.281, OBAAway =0.263, FP = 0.981, DefEff = 0.687 },           //4
            new Objects.Team() { Name = "Red Sox", Abbrev = "BOS", City = "Boston", OPS = 0.824, ABHR = 23.3, TeamRBI = 5.54, OBAHome = 0.249, OBAAway =0.253, FP = 0.984, DefEff = 0.675 },              //5
            new Objects.Team() { Name = "Cubs", Abbrev = "CHC", City = "Chicago", OPS = 0.774, ABHR = 21.9, TeamRBI = 4.75, OBAHome = 0.237, OBAAway =0.263, FP = 0.982, DefEff = 0.687 },                //6
            new Objects.Team() { Name = "White Sox", Abbrev = "CWS", City = "Chicago", OPS = 0.703, ABHR = 30.3, TeamRBI = 3.89, OBAHome = 0.254, OBAAway =0.271, FP = 0.978, DefEff = 0.678 },           //7
            new Objects.Team() { Name = "Reds", Abbrev = "CIN", City = "Cincinnati", OPS = 0.737, ABHR = 24.7, TeamRBI = 4.32, OBAHome = 0.237, OBAAway =0.247, FP = 0.986, DefEff = 0.691 },             //8
            new Objects.Team() { Name = "Indians", Abbrev = "CLE", City = "Clevland", OPS = 0.749, ABHR = 25.1, TeamRBI = 4.35, OBAHome = 0.236, OBAAway =0.237, FP = 0.985, DefEff = 0.696 },            //9
            new Objects.Team() { Name = "Rockies", Abbrev = "COL", City = "Colorado", OPS = 0.776, ABHR = 27.9, TeamRBI = 5.15, OBAHome = 0.296, OBAAway =0.255, FP = 0.985, DefEff = 0.675 },           //10
            new Objects.Team() { Name = "Tigers", Abbrev = "DET", City = "Detroit", OPS = 0.671, ABHR = 36.7, TeamRBI = 3.42, OBAHome = 0.280, OBAAway =0.260, FP = 0.980, DefEff = 0.674 },          //11
            new Objects.Team() { Name = "Marlins", Abbrev = "MIA", City = "Miami", OPS = 0.651, ABHR = 40.7, TeamRBI = 3.50, OBAHome = 0.243, OBAAway =0.243, FP = 0.985, DefEff = 0.706 },         //12
            new Objects.Team() { Name = "Astros", Abbrev = "HOU", City = "Houston", OPS = 0.822, ABHR = 23.9, TeamRBI = 5.05, OBAHome = 0.215, OBAAway =0.229, FP = 0.987, DefEff = 0.719 },        //13
            new Objects.Team() { Name = "Royals", Abbrev = "KCR", City = "Kansas City", OPS = 0.710, ABHR = 36.3, TeamRBI = 4.06, OBAHome = 0.273, OBAAway =0.272, FP = 0.988, DefEff = 0.677 },       //14
            new Objects.Team() { Name = "Dodgers", Abbrev = "LAD", City = "Los Angeles", OPS = 0.811, ABHR = 20.4, TeamRBI = 5.27, OBAHome = 0.214, OBAAway =0.238, FP = 0.981, DefEff = 0.708 },      //15
            new Objects.Team() { Name = "Brewers", Abbrev = "MIL", City = "Milwaukee", OPS = 0.772, ABHR = 21.2, TeamRBI = 4.68, OBAHome = 0.234, OBAAway =0.272, FP = 0.984, DefEff = 0.687 },     //16
            new Objects.Team() { Name = "Twins", Abbrev = "MIN", City = "Minnesota", OPS = 0.835, ABHR = 18.2, TeamRBI = 5.50, OBAHome = 0.259, OBAAway =0.251, FP = 0.881, DefEff = 0.678 },    //17
            new Objects.Team() { Name = "Mets", Abbrev = "NYM", City = "New York", OPS = 0.752, ABHR = 24.4, TeamRBI = 4.52, OBAHome = 0.240, OBAAway =0.261, FP = 0.981, DefEff = 0.679 },   //18
            new Objects.Team() { Name = "Athletics", Abbrev = "OAK", City = "Oakland", OPS = 0.760, ABHR = 22.0, TeamRBI = 4.70, OBAHome = 0.239, OBAAway =0.252, FP = 0.986, DefEff = 0.709 },  //19
            new Objects.Team() { Name = "Phillies", Abbrev = "PHI", City = "Philadelphia", OPS = 0.744, ABHR = 26.6, TeamRBI = 4.57, OBAHome = 0.261, OBAAway =0.266, FP = 0.984, DefEff = 0.686 }, //20
            new Objects.Team() { Name = "Blue Jays", Abbrev = "TOR", City = "Toronto", OPS = 0.718, ABHR = 23.3, TeamRBI = 4.28, OBAHome = 0.259, OBAAway =0.260, FP = 0.985, DefEff = 0.686 },//21
            new Objects.Team() { Name = "Pirates", Abbrev = "PIT", City = "Pittsburgh", OPS = 0.750, ABHR = 32.9, TeamRBI = 4.58, OBAHome = 0.266, OBAAway =0.264, FP = 0.980, DefEff = 0.670 },          //22
            new Objects.Team() { Name = "Padres", Abbrev = "SDP", City = "San Diego", OPS = 0.740, ABHR = 21.9, TeamRBI = 4.27, OBAHome = 0.246, OBAAway =0.260, FP = 0.980, DefEff = 0.681 },         //23
            new Objects.Team() { Name = "Giants", Abbrev = "SFG", City = "San Francisco", OPS = 0.698, ABHR = 32.7, TeamRBI = 4.20, OBAHome = 0.243, OBAAway =0.263, FP = 0.985, DefEff = 0.694 },         //24
            new Objects.Team() { Name = "Cardinals", Abbrev = "STL", City = "St. Louis", OPS = 0.727, ABHR = 26.3, TeamRBI = 4.28, OBAHome = 0.228, OBAAway =0.254, FP = 0.988, DefEff = 0.701 },         //25
            new Objects.Team() { Name = "Rays", Abbrev = "TBR", City = "Tampa Bay", OPS = 0.760, ABHR = 26.5, TeamRBI = 4.46, OBAHome = 0.226, OBAAway =0.237, FP = 0.985, DefEff = 0.697 },               //26
            new Objects.Team() { Name = "Nationals", Abbrev = "WSH", City = "Washington", OPS = 0.771, ABHR = 25.0, TeamRBI = 4.73, OBAHome = 0.260, OBAAway =0.236, FP = 0.985, DefEff = 0.684 },        //27
            new Objects.Team() { Name = "Mariners", Abbrev = "SEA", City = "Seattle", OPS = 0.767, ABHR = 21.4, TeamRBI = 4.86, OBAHome = 0.257, OBAAway =0.278, FP = 0.976, DefEff = 0.683 },            //28
            new Objects.Team() { Name = "Rangers", Abbrev = "TEX", City = "Texas", OPS = 0.769, ABHR = 23.9, TeamRBI = 5.05, OBAHome = 0.274, OBAAway =0.263, FP = 0.982, DefEff = 0.669 },               //29
            new Objects.Team() { Name = "Yankees", Abbrev = "NYY", City = "New York", OPS = 0.815, ABHR = 20.4, TeamRBI = 5.50, OBAHome = 0.236, OBAAway =0.265, FP = 0.982, DefEff = 0.688 },             //30

        };
            
        public static void CurrentTeams(List<Objects.Team> Teams)
        {
            var rowCount = 0;
            var colCount = 0;
            foreach (Objects.Team team in Teams)
            {
                Output.WriteStringOutput($"{team.Abbrev} for {team.City} {team.Name}", 2 + (colCount * 30), 4 + rowCount);
                rowCount++;
                if (rowCount == 21)
                {
                    rowCount = 0;
                    colCount++;
                }
                    
            }
        }

        public void SettingNewTeam(Objects.Team team, MLB mlb, string choice, bool atAway)
        {
            if (!mlb.Teams.Any(T => T.Abbrev.ToLower().Equals(choice.ToLower())))
            {
                team.Abbrev = choice;
                team.Name = choice;
                Output.WriteStringOutput("What DefEff you want this team to have? MLB average is 0.687, right now ranging from 0.669-0.719");
                team.DefEff = Convert.ToDouble(Console.ReadLine());
                Output.WriteStringOutput("Just need 2 more things. Fielding Recentage? MLB average is 0.983, right now ranging from 0.976-0.989");
                team.FP = Convert.ToDouble(Console.ReadLine());

                if (atAway)
                {
                    Output.WriteStringOutput("What about On-Base Average (Pitching) when playing at Away? MLB is right now ranging between 0.229-0.278");
                    team.OBAAway = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    Output.WriteStringOutput("What about On-Base Average (Pitching) when playing at Home? MLB is right now ranging between 0.214-0.298");
                    team.OBAHome = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

    }

}
