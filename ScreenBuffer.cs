using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallPark3
{
    public class ScreenBuffer
    {
        //initiate important variables
        public static char[,] screenBufferArray = new char[120, 27]; //main buffer array
        public static string screenBuffer; //buffer as string (used when drawing)
        public static Char[] arr; //temporary array for drawing string
        public static int i = 0; //keeps track of the place in the array to draw to

        //this method takes a string, and a pair of coordinates and writes it to the buffer
        public static void Draw(string text, int x, int y)
        {
            //split text into array
            arr = text.ToCharArray(0, text.Length);
            //iterate through the array, adding values to buffer 
            i = 0;
            foreach (char c in arr)
            {
                screenBufferArray[(x-1) + i, (y-1)] = c;
                i++;
            }
        }

        public static void DrawScreen()
        {
            screenBuffer = "";
            //iterate through buffer, adding each value to screenBuffer
            for (int iy = 0; iy < 27; iy++)
            {
                for (int ix = 0; ix < 120; ix++)
                {
                    screenBuffer += screenBufferArray[ix, iy];
                }
            }
            //set cursor position to top left and draw the string
            Console.SetCursorPosition(0, 0);
            Console.Write(screenBuffer);
            screenBufferArray = new char[120, 27];
            //note that the screen is NOT cleared at any point as this will simply overwrite the existing values on screen. Clearing will cause flickering again.
        }

    }
}
