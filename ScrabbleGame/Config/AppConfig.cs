using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleGame.Config
{
    public static class AppConfig
    {
        public static String appendixFilePath = ConfigurationManager.AppSettings["appendixFilePath"];
        public static String tileFilePath = ConfigurationManager.AppSettings["tileFilePath"];
        public static int playerCount = Convert.ToInt32(ConfigurationManager.AppSettings["playerCount"]);
        public static int drawCount = Convert.ToInt32(ConfigurationManager.AppSettings["drawCount"]);
    }
}
