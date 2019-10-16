using System;
using System.Collections.Generic;
using System.Threading;
using BallPark3.Objects;


namespace BallPark3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ctor
            Console.SetWindowSize(120, 28);

            Output.ScreenOutput = new List<Tuple<string, int, int>>();
            Output.StartTimer();

            BallPark3.ApplicationData.DefaultApplicationFolder = "BallPark";
            BallPark3.ApplicationData.DefaultCompanyFolder = "Oddsphere";
            BallPark3.ApplicationData.DefaultAdditionalPath = "";

            var DataFolder = new BallPark3.ApplicationData().ApplicationFolderPath;

            var teams = new MLB();
            var players = new PlayersRoster();
            var teamManagerOne = new TeamManager();
            var teamManagerTwo = new TeamManager();
            var teamOneTotal = 0;
            var teamTwoTotal = 0;
            //var Squad = (Objects.Team)TeamManager;
            #endregion

            players.Players = BallPark3.Serialization.ReadObject<List<Objects.Player>>(System.IO.File.ReadAllBytes(DataFolder + "\\players.dat"));
            teams.Teams = BallPark3.Serialization.ReadObject<List<Objects.Team>>(System.IO.File.ReadAllBytes(DataFolder + "\\teams.dat"));

            Output.WriteStringOutput("Ready? (y/n)", 2, 2);
            var input = Console.ReadLine();
            Output.ClearScreen();

            while (input != "")
            {
                if (!input.Equals("n"))
                {
                    Random random = new Random();
                    MLB.CurrentTeams(teams.Teams);
                    Output.WriteStringOutput("Choose a team to play: ", 2, 2);
                    var teamOne = new Team();
                    var inputOne = Console.ReadLine();
                    teamOne = TeamManager.TeamSelection(teams.Teams, inputOne.ToLower());
                    players.SetBattingOrder(teamOne, teams, players, teamManagerOne);
                    if (teamOne.Abbrev == null)
                    {
                        teamOne.Abbrev = inputOne;
                        teamOne.Name = inputOne;
                    };
                    teams.SettingNewTeam(teamOne, teams, inputOne, true);

                    Output.WriteStringOutput("Who is the second team?", 2, 2);
                    var teamTwo = new Team();
                    var inputTwo = Console.ReadLine();
                    teamTwo = TeamManager.TeamSelection(teams.Teams, inputTwo.ToLower());
                    players.SetBattingOrder(teamTwo, teams, players, teamManagerTwo);
                    if (teamTwo.Abbrev == null)
                    {
                        teamTwo.Abbrev = inputTwo;
                        teamTwo.Name = inputTwo;
                    };
                    teams.SettingNewTeam(teamTwo, teams, inputTwo, false);

                    Output.WriteStringOutput($"\n   {teamOne.Name} vs. {teamTwo.Name}");

                    for (var i = 0; i < 9; i++)
                    {
                        var top = new Inning();
                        Output.WriteStringOutput($"\nInning {i + 1}");
                        top.GameOn(players, teamOne, teamTwo, teamOne.OBAAway, teamManagerOne);
                        Output.WriteStringOutput($"\n{teamOne.Abbrev} {top.HomeRuns}\n");

                        var bottom = new Inning();
                        bottom.GameOn(players, teamTwo, teamOne, teamTwo.OBAHome, teamManagerTwo);
                        Output.WriteStringOutput($"\n{teamTwo.Abbrev} {bottom.HomeRuns}\n");

                        teamOneTotal += top.HomeRuns;
                        teamTwoTotal += bottom.HomeRuns;
                        Output.WriteStringOutput($"\nAfter Inning {i + 1} - \n{teamOne.Abbrev} {teamOneTotal}\n{teamTwo.Abbrev} {teamTwoTotal}\n");
                        int milliseconds = 2000;
                        Thread.Sleep(milliseconds);
                    }


                    if (teamOneTotal == teamTwoTotal)
                    {
                        Output.WriteStringOutput($"\nIt was a tie\n{teamOne.City} {teamOne.Name} {teamOneTotal}\n{teamTwo.City} {teamTwo.Name} {teamTwoTotal}");
                    }
                    else if (teamTwoTotal > teamOneTotal)
                    {
                        Output.WriteStringOutput($"\n{teamTwo.City} {teamTwo.Name} won {teamTwoTotal}:{teamOneTotal}");
                    }
                    else
                    {
                        Output.WriteStringOutput($"\n{teamOne.City} {teamOne.Name} won {teamOneTotal}:{teamTwoTotal}");
                    }

                    input = Console.ReadLine();
                    teamOneTotal = 0;
                    teamTwoTotal = 0;

                }
                else break;

            }
            Output.WriteStringOutput("Goodbye");

            
            }
        

    }
}
