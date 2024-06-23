using Newtonsoft.Json;
using ScrabbleGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame
{
    internal class Scrabble
    {       
        List<ScrabbleTile> Tiles {  get; set; }
        List<String> Appendix {  get; set; }
        List<Player> Players { get; set; }

        public Scrabble()
        {
            Tiles = new List<ScrabbleTile>();
            Appendix = new List<string>();
            Players = new List<Player>();
        }

        public void LoadConfigs()
        {
            string tileFileName = "TilesConfig.json";
            string tilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\InputFiles\", tileFileName);
            string tileJsonString = File.ReadAllText(tilePath);

            Tiles = JsonConvert.DeserializeObject<List<ScrabbleTile>>(tileJsonString);

            string appendixFileName = "Appendix.txt";
            string appendixPath = Path.Combine(Environment.CurrentDirectory, @"..\..\InputFiles\", appendixFileName);
            Appendix = File.ReadAllLines(appendixPath).ToList();
        }

        public void DrawTiles()
        {
            int NoOfPlayers = 2;
            int NoOfTiles = 7;
            
            Random random = new Random();
            int index = 0;
            String word = "";

            for (int i = 0; i < NoOfPlayers; i++)
            {
                Player player = new Player();

                for (int j = 0; j < NoOfTiles;)
                {
                    index = random.Next(Tiles.Count);

                    if (Tiles[index].Distributions > 0)
                    {
                        word += Tiles[index].Symbol;
                        Tiles[index].Distributions--;
                        j++;
                    }
                }

                player.word = word;
                word = "";
                Players.Add(player);
            }

            foreach (Player player in Players)
            {
                Console.WriteLine(player.word);
            }
        }

        public void StartGame() 
        {
            Console.WriteLine("Loading Game...\n");

            LoadConfigs();

            DrawTiles();


        }
    }
}
