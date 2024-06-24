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
            Word = String.Empty;
            Combinations = new List<Combination>();
        }

        public void Play(List<String> appendix, List<ScrabbleTile> tileBag)
        {
            String temp = Word;
            int isExist = 0;

            if (temp.Contains("?"))
                temp.Replace("?", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    if (i != j)
                    {
                        Combination combination = new Combination();
                        combination.Word = $"{temp[i]}{temp[j]}";

                        isExist = Combinations.FindIndex(com => com.Word.Equals(combination.Word));
                                                
                        if (isExist < 0 && appendix.Contains(combination.Word.ToLower()))
                        {
                            ScrabbleTile tile1 = tileBag.Find(x => x.Symbol == combination.Word[0]);
                            ScrabbleTile tile2 = tileBag.Find(x => x.Symbol == combination.Word[1]);
                            combination.Value = tile1.Points + tile2.Points;

                            Combinations.Add(combination);
                        }
                    }
                }
            }
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
