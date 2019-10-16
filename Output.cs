using System;
using System.Collections.Generic;

namespace BallPark3
{
    public static class Output
    {
        public static List<Tuple<string, int, int>> ScreenOutput { get; set; }
        public static System.Timers.Timer WriteTimer { get; set; }

        public static void BuildFrame()
        {
            for (int i = 1; i <= 27; i++)
            {
                ScreenBuffer.Draw("#", 1, i);
                ScreenBuffer.Draw("#", 120, i);
            }

            for (int i = 1; i <= 120; i++)
            {
                ScreenBuffer.Draw("#", i, 1);
                ScreenBuffer.Draw("#", i, 27);
            }
        }

        public static void StartTimer()
        {
            WriteTimer = new System.Timers.Timer();
            WriteTimer.Interval = 1000;
            WriteTimer.AutoReset = false;
            WriteTimer.Elapsed += WriteOutput;
            WriteTimer.Start();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputString"></param>
        /// <param name="x">Value between 1-116</param>
        /// <param name="y">Value between 1-25</param>
        public static void WriteStringOutput(string outputString, int x, int y)
        {
            ScreenOutput.Add(new Tuple<string, int, int>(outputString, x+1, y+1));
        }

        public static void WriteStringOutput(string outputString)
        {
            ScreenOutput.Add(new Tuple<string, int, int>(outputString, 1, 1));
        }

        public static void ClearScreen()
        {
            ScreenOutput.Clear();
        }

        public static void WriteOutput(object sender, System.Timers.ElapsedEventArgs e)
        {
            BuildFrame();

            foreach (var outputString in ScreenOutput)
            {
                ScreenBuffer.Draw(outputString.Item1, outputString.Item2, outputString.Item3);
                //Console.Write(outputString);
            }

            ScreenBuffer.DrawScreen();

            WriteTimer.Start();
        }
    }
}
