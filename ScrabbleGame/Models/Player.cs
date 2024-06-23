using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame.Models
{
    internal class Player
    {
        public String Word  { get; set; }
        public List<Combination> Combinations { get; set; }

        public Player() 
        {
            Word = "";
            Combinations = new List<Combination>();
        }

        public void PrintWord()
        {
            Console.WriteLine(Word);
        }

        public void PrintAll()
        {
            Console.WriteLine(this.Word);

            if (this.Combinations.Count > 0)
            {
                foreach (Combination combination in this.Combinations)
                {
                    Console.Write(combination.Word.ToLower() + " (" + combination.Value + ") ");
                }
            }
            else
            {
                Console.Write(0);
            }

            Console.WriteLine();
        }
    }
}
