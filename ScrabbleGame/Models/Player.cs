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
            Combinations = new List<Combination>();
        }
    }
}
