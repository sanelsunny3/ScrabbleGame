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
            Console.WriteLine("...Welcome to Scrabble Board Game...");
            Console.WriteLine("...Do you wish to play (y/n)...");

            String flag = Console.ReadLine();

            if(flag.ToLower() != "n")
            {
                Scrabble scrabble = new Scrabble();
                scrabble.StartGame();
            }            

            Console.ReadLine();
        }
    }
}
