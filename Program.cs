using System;

namespace MyApp; // Note: actual namespace depends on the project name.
class Program {
    static void Main(string[] args) {
        Player player = new Player('X');
        Player player1 = new Player('Y');
        Game.LaunchGame();
    }
}
