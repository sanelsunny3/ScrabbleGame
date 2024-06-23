using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame.Models
{
    internal class Player
    {
        public String word  { get; set; }
        public List<String> combinations { get; set; }
    }
}
