using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Welcome to Scrabble Board Game***");            
            
            try
            { 
                String flag = String.Empty;
                do
                {
                    Scrabble scrabble = new Scrabble();
                    scrabble.StartGame();                        

                    Console.WriteLine("\n***Do you wish to play again (y/n)***");
                    flag = Console.ReadLine();
                }
                while (flag.ToLower() != "n");

                Console.WriteLine("***End Game***");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }                                    
        }
    }
}
