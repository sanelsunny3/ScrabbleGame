using Newtonsoft.Json;
using ScrabbleGame.Config;
using ScrabbleGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame
{
    internal class Scrabble
    {       
        List<ScrabbleTile> TileBag {  get; set; }
        List<String> Appendix {  get; set; }
        List<Player> Players { get; set; }
        int PlayerCount { get; set; }
        int DrawCount { get; set; }

        public Scrabble()
        {
            TileBag = new List<ScrabbleTile>();
            Appendix = new List<string>();
            Players = new List<Player>();
        }

        public void LoadConfigs()
        {
            try
            {                
                string tilePath = Path.Combine(Environment.CurrentDirectory, AppConfig.tileFilePath);
                string tileJsonString = File.ReadAllText(tilePath);

                TileBag = JsonConvert.DeserializeObject<List<ScrabbleTile>>(tileJsonString);

                string appendixPath = Path.Combine(Environment.CurrentDirectory, AppConfig.appendixFilePath);
                Appendix = File.ReadAllLines(appendixPath).ToList();

                PlayerCount = AppConfig.playerCount;
                DrawCount = AppConfig.drawCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DrawTiles(int playerCount = 2, int drawCount = 7)
        {            
            Random random = new Random();
            int index = 0;
            String word = "";

            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player();

                for (int j = 0; j < drawCount;)
                {
                    index = random.Next(TileBag.Count);

                    if (TileBag[index].Distributions > 0)
                    {
                        word += TileBag[index].Symbol;
                        TileBag[index].Distributions--;
                        j++;
                    }
                }

                player.Word = word;
                word = "";
                Players.Add(player);
            }

            Console.WriteLine();

            foreach (Player player in Players)
            {
                Console.WriteLine(player.Word);
            }

            Console.WriteLine();
        }

        public void DrawTilesTest()
        {            
            Player player1 = new Player();
            player1.Word = "FPDTP??";                
            Players.Add(player1);

            Player player2 = new Player();
            player2.Word = "CJFLQWW";
            Players.Add(player2);            

            foreach (Player player in Players)
            {
                Console.WriteLine(player.Word);
            }

            Console.WriteLine();
        }

        public void LoadCombinations()
        {
            foreach (Player player in Players)
            {
                if (player.Word.Contains("?"))
                    player.Word.Replace("?", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");

                for (int i = 0; i < player.Word.Length; i++)
                {
                    for (int j = 0; j < player.Word.Length; j++)
                    {
                        if (i != j)
                        {
                            Combination combination = new Combination();
                            combination.Word = $"{player.Word[i]}{player.Word[j]}";

                            if (Appendix.Contains(combination.Word.ToLower()))
                            {                               
                                ScrabbleTile tile1 = TileBag.Find(x => x.Symbol == combination.Word[0]);
                                ScrabbleTile tile2 = TileBag.Find(x => x.Symbol == combination.Word[1]);
                                combination.Value = tile1.Points + tile2.Points;
                                
                                player.Combinations.Add(combination);
                            }
                        }
                    }
                }
            }
        }

        public void StartGame() 
        {
            try
            {
                LoadConfigs();

                DrawTiles(PlayerCount, DrawCount);

                //DrawTilesTest();

                LoadCombinations();

                foreach (Player player in Players)
                {
                    player.PrintAll();
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
