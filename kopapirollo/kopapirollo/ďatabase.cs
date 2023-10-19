using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace kopapirollo {

    class Game {
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }
        public int GameResult { get; private set; }

        public Game(string p1, string p2, int r) {
            Player1 = p1;
            Player2 = p2;
            GameResult = r;
        }
    }

    class Player {
        public string Name { get; private set; }
        public int WinCount { get; private set; }
        public int LoseCount { get; private set; }
        public int DrawCount { get; private set; }

        public Player(Game game) {

        }
    }

    static class Program {
        static void Main(string[] args) {

        }
    }
}