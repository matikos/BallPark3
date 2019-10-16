using BallPark3.Objects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BallPark3
{
    public class Inning
    {
        public int HomeRuns;
        public int Outs;
        private List<Objects.Player> Hitters;

        public Inning()
        {
            Hitters = new List<Objects.Player>();
        }

        public void GameOn(PlayersRoster players, Team teamBatting, Team teamFielding, Double FieldingTeamAvg, TeamManager teamManager)
        {
            do
            {
                Hitters.Add(players.NextBatter(teamBatting, teamManager));
                //Hitters.Distinct().ToList();
                Output.WriteStringOutput($"\n{Hitters[Hitters.Count - 1].Name} at the bat");

                BattersUp.Swing(Hitters[Hitters.Count - 1], teamBatting, teamFielding, FieldingTeamAvg);
                Output.WriteStringOutput($" ...and he hits {BattersUp.Hits}");

                if (BattersUp.Hits == 0)
                {
                    Outs++;
                    Output.WriteStringOutput(" --You're OUT!");
                }
                else if (BattersUp.Hits == 4)
                {
                    Output.WriteStringOutput(" --HOMERUN!");
                }
                else
                {
                    Output.WriteStringOutput("");
                    Hitters[Hitters.Count - 1].RemoveBatter = false;
                }

                int milliseconds = 1500;
                Thread.Sleep(milliseconds);

                foreach (Objects.Player player in Hitters)
                {
                    player.OnBase += BattersUp.Hits;

                    if (player.OnBase >= 4)
                    {
                        HomeRuns++;
                        player.RemoveBatter = true;
                        player.OnBase = 0;
                    }
                    else if (player.OnBase == 0)
                    {

                        player.RemoveBatter = true;
                    }
                    else
                    {
                        player.RemoveBatter = false;
                    }
                }

                Hitters.RemoveAll(T => T.RemoveBatter==true);
               

            } while (Outs < 3);

            players.ResetBatter();
        }
        public class BattersUp
        {
            public static int Hits;
            public static void Swing(Objects.Player player, Team teamBatting, Team teamFielding, Double FieldingTeamAvg)
            {
                Random random = new Random();
                Hits = random.NextDouble() < (player.AVG + FieldingTeamAvg) - (teamFielding.FP/10) ? Odds.Calculate(random, teamFielding.DefEff) : 0;
            }

        }
    }
}