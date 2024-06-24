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
                //Loads Tile details from input file
                string tilePath = Path.Combine(Environment.CurrentDirectory, AppConfig.tileFilePath);
                string tileJsonString = File.ReadAllText(tilePath);

                TileBag = JsonConvert.DeserializeObject<List<ScrabbleTile>>(tileJsonString);

                //Loads Appendix details from input file
                string appendixPath = Path.Combine(Environment.CurrentDirectory, AppConfig.appendixFilePath);
                Appendix = File.ReadAllLines(appendixPath).ToList();

                //Initialize default count
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
            
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player();

                for (int j = 0; j < drawCount;)
                {
                    index = random.Next(TileBag.Count);

                    if (TileBag[index].Distributions > 0)
                    {
                        player.Word += TileBag[index].Symbol;
                        TileBag[index].Distributions--;
                        j++;
                    }
                }
                
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
            player1.Word = "OUKWDES";                
            Players.Add(player1);

            Player player2 = new Player();
            player2.Word = "ZEROOHI";
            Players.Add(player2);            

            foreach (Player player in Players)
            {
                Console.WriteLine(player.Word);
            }

            Console.WriteLine();
        }        

        public void StartGame() 
        {
            try
            {
                //Initialize settings and list of appendix and tile bag for the game
                LoadConfigs();

                //Generates scrabble word for each player
                DrawTiles();

                //Test method that contains default scrabble word
                //DrawTilesTest();

                //Generates valid word combinations for each player
                Players.ForEach(player => player.Play(Appendix, TileBag));

                //Print the combinations and score of each player
                Players.ForEach(player => player.PrintAll());
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
