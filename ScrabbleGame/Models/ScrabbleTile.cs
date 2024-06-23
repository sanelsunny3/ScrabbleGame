using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame.Models
{
    internal class ScrabbleTile
    {
        public ScrabbleTile(char symbol, int distributions, int points)
        {
            Symbol = symbol;
            Distributions = distributions;
            Points = points;
        }

        public char Symbol { get; set; }
        public int Distributions { get; set; }
        public int Points { get; set; }
    }
}
