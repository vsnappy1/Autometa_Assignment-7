using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToCS_Assignment_7
{
    /********************************************************************************************************
     Objective:
     Construct a Sensor Machine which counts the occurance of 'babb' in the given string
      ******************************************************************************************************/
    class Program
    {
        //This Function prints the Transition Table
        public static void printTransitionTable(int[,] arr)
        {
            Console.WriteLine();
            Console.WriteLine("State | 0   1  Output ");
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                Console.Write("q" + r + "    |");
                for (int c = 0; c < arr.GetLength(1); c++)
                {
                    if (c < 2)
                        Console.Write(" q" + arr[r, c] + " ");
                    else
                        Console.Write("  " + arr[r, c] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int column, i, r, nextState, count=0;
            string str, chr;

            int[,] transitionTable = new int[5,3];                  //Initialize the matrix of 5 by 3

            {                                       //This block of code fills the martx/Transition Table with the values of Moore Machine
                //Column 0 entries                      //which counts the occurance of babb
                transitionTable[0, 0] = 0;
                transitionTable[1, 0] = 2;
                transitionTable[2, 0] = 0;
                transitionTable[3, 0] = 2;
                transitionTable[4, 0] = 0;

                //Column 1 entries
                transitionTable[0, 1] = 1;
                transitionTable[1, 1] = 1;
                transitionTable[2, 1] = 3;
                transitionTable[3, 1] = 4;
                transitionTable[4, 1] = 1;

                //Column 2 entries (Output)
                transitionTable[0, 2] = 0;
                transitionTable[1, 2] = 0;
                transitionTable[2, 2] = 0;
                transitionTable[3, 2] = 0;
                transitionTable[4, 2] = 1;
            }

            printTransitionTable(transitionTable);              //This prints the Transition Table

            while (true)
            {
                Console.Write("\nEnter String : ");
                str = Console.ReadLine();
                r = 0;      i = 0;      count = 0;                  //Make all variable 0 before after entring a string
                while (i < str.Length)                              //This Loop traverse the Nodes/Transition Table and reaches the end of the string
                {
                    chr = Convert.ToString(str[i]);                 //chr contains the i'th character of string
                    if (chr == "a")                                 //Here 'a' means we need to see in column 0
                        column = 0;
                    else
                        column = 1;

                    nextState = transitionTable[r, column];         //element of (r,i'th character) moves the machine to nextState
                    r = nextState;                                  //r contains the row number of next state
                    i++;

                    if (transitionTable[r, 2] == 1)                 //This counts the occurance of babb, if
                        count++;
                }
                Console.WriteLine();

                Console.WriteLine("Output : " + count);             //Here we see the output of (r,2)
                Console.ReadKey();
            }
        }
    }
}
