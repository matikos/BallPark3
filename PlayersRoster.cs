using System.Collections.Generic;
using System.Linq;

namespace BallPark3
{
    public class PlayersRoster
    {
        public int Turn;

        public PlayersRoster()
        {
            Turn = 0;
        }

        //2019 MLB top 158 players (+ MJ, the Captain and me) + 30 Generic Players each one with team AVG
        public List<Objects.Player> Players = new List<Objects.Player>();

        public Objects.Player NextBatter(Objects.Team team, TeamManager teamManager)
        {
            if (Turn < teamManager.BattingOrder.Count)
            {
                Turn++;
            }
            else Turn = 1;

            return teamManager.BattingOrder[Turn - 1].Clone() as Objects.Player;
        }

        public void ResetBatter()
        {
            foreach (var player in Players)
            {
                player.OnBase = 0;
                player.RemoveBatter = false;

            }
            Turn += 1; ;
        }

        public void SetBattingOrder(Objects.Team team, MLB mlb, PlayersRoster players, TeamManager teamManager)
        {
            //team.battingOrder = Players.Where(T => T.Team.Equals(team.Abbrev)).DefaultIfEmpty().ToList();
            if (mlb.Teams.Any(T => T.Abbrev.Equals(team.Abbrev))){
                teamManager.BattingOrder = Players.Where(T => T.Team.Equals(team.Abbrev)).DefaultIfEmpty().ToList();
            }
            else
            {
                PickLineUp lineUp = new PickLineUp();
                teamManager.BattingOrder = lineUp.GetPlayers(players, mlb);
            }
        }
    }
}
