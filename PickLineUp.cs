using System;
using System.Collections.Generic;
using System.Linq;

namespace BallPark3
{
    class PickLineUp
    {
        private List<Objects.Player> battingOrder = new List<Objects.Player>();

        public List<Objects.Player> GetPlayers(PlayersRoster players, MLB mlb)
        {
            int inputNumber = 0;

            Output.WriteStringOutput("\n\nHow do you want choose your players? \nChoose number: " +
               "\n1-Random (5 players)" +
               "\n2-based on Batting Average (any qualifying player)" +
               "\n3-specific Team line up" +
               "\n4-pick players by name (5 players):\n");
            inputNumber = Convert.ToInt32(Console.ReadLine());
            
            while (inputNumber == 0 || inputNumber > 4)
            {
                Output.WriteStringOutput("Invalid choice. Try again");
                Output.WriteStringOutput("\n\nHow do you want choose your players? \nChoose number: " +
                "\n1-Random (5 players)" +
                "\n2-based on Batting Average (any qualifying player)" +
                "\n3-specific Team line up" +
                "\n4-pick players by name (5 players):\n");
                inputNumber = Convert.ToInt32(Console.ReadLine());
            } ;
            
            switch (inputNumber) 
            {
                case 1: //Choose 5 random players
                    Random random = new Random();
                    battingOrder.Add(players.Players[random.Next(0, 190)]);
                    battingOrder.Add(players.Players[random.Next(0, 190)]);
                    battingOrder.Add(players.Players[random.Next(0, 190)]);
                    battingOrder.Add(players.Players[random.Next(0, 190)]);
                    battingOrder.Add(players.Players[random.Next(0, 190)]);
                    break;

                case 2:
                    Output.WriteStringOutput("What's the minimum Batting Averge one has to have to qualify for your team? - ");
                    double Ba = Convert.ToDouble(Console.ReadLine());
                    battingOrder = players.Players.Where(T => T.AVG > Ba).ToList();
                break;

                case 3:
                    Output.WriteStringOutput("Which team's line up you want to take over? (Scroll up for the list) - ");
                    string whichTeam = Console.ReadLine().ToLower();
                    battingOrder = players.Players.Where(T => T.Team.ToLower().Equals(whichTeam)).ToList();
                    break;

                case 4:
                    Output.WriteStringOutput("So who are you drafting? - ");
                    string whichPlayer = Console.ReadLine().ToLower();
                    var i = 5;
                    do
                    {
                        if (!players.Players.Any(T => T.Name.ToLower().Equals(whichPlayer)))
                        {
                            Output.WriteStringOutput("Dont have this player. Please check for correct spelling.\n");
                            whichPlayer = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            battingOrder.Add(players.Players.Where(T => T.Name.ToLower().Equals(whichPlayer)).SingleOrDefault());
                            i--;
                            Output.WriteStringOutput($"\nGood choice! {i} more player(s) - ");
                            whichPlayer = Console.ReadLine().ToLower();

                        }
                    } while (i > 0);

                    break;
            }

            battingOrder.OrderBy(T => T.AVG);
            return battingOrder;
        }
    }
}
