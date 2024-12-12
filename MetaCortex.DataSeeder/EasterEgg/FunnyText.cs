using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCortex.DataSeeder.EasterEgg
{
    public static class FunnyText
    {
        public static List<string> IntroText()
        {
            List<string> fancyText = new List<string>
        {
            "███╗   ███╗███████╗████████╗ █████╗  ██████╗ ██████╗ ██████╗ ████████╗███████╗██╗  ██╗",
            "████╗ ████║██╔════╝╚══██╔══╝██╔══██╗██╔════╝██╔═══██╗██╔══██╗╚══██╔══╝██╔════╝╚██╗██╔╝",
            "██╔████╔██║█████╗     ██║   ███████║██║     ██║   ██║██████╔╝   ██║   █████╗   ╚███╔╝ ",
            "██║╚██╔╝██║██╔══╝     ██║   ██╔══██║██║     ██║   ██║██╔══██╗   ██║   ██╔══╝   ██╔██╗ ",
            "██║ ╚═╝ ██║███████╗   ██║   ██║  ██║╚██████╗╚██████╔╝██║  ██║   ██║   ███████╗██╔╝ ██╗",
            "╚═╝     ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝",
            "                                                                                      "
        };
            return fancyText;
        }
        public static List<string> PantherText()
        {
            List<string> asciiArt = new List<string>
        {
            "  _____            _   _               ",
            " |  __ \\          | | | |              ",
            " | |__) |_ _ _ __ | |_| |__   ___ _ __ ",
            " |  ___/ _` | '_ \\| __| '_ \\ / _ \\ '__|",
            " | |  | (_| | | | | |_| | | |  __/ |   ",
            " |_|   \\__,_|_| |_|\\__|_| |_|\\___|_|   ",
            "                                       ",
            "                                       "
        };
            return asciiArt;
        }
    }
}
