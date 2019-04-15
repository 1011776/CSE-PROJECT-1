using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
    class Program {
        static void Main(string[] args) {
            GameState gs = NewGame();
            while (gs.current != "quit") {
                switch (gs.current) {
                    case "inn":
                        Inn(gs);
                        break;
                    case "letter":
                        Letter(gs);
                        break;
                    case "armoury":
                        Armoury(gs);
                        break;
                    case "ambush":
                        Ambush(gs);
                        break;
                    case "sharnwick":
                        Sharnwick(gs);
                        break;
                    case "hideout":
                        Hideout(gs);
                        break;
                    case "captured":
                        Captured(gs);
                        break;
                    case "win":
                        Win(gs);
                        break;
                    case "lose":
                        Lose(gs);
                        break;
                    default:
                        Console.WriteLine("An unexpected error has occured, the software will now quit");
                        Console.ReadKey();
                        gs.current = "quit";
                        break;
                }
            }
        }

        static void Inn(GameState gs) {


        }
        static void Letter(GameState gs) {

        }
        static void Armoury(GameState gs) {

        }

        static void Ambush(GameState gs) {

        }

        static void Sharnwick(GameState gs) {

        }

        static void Hideout(GameState gs) {

        }

        static void Captured(GameState gs) {

        }

        static void Win(GameState gs) {

        }

        static void Lose(GameState gs) {

        }

        static bool HasItem(GameState gs, string item) {
            for (int i = 0; i < gs.inventory.Count(); i++) {
                if (item == gs.inventory[i]) {
                    return true;
                }
            }
            return false;
        }

        static GameState NewGame() {
            GameState gs = new GameState();
            gs.current = "quit";
            gs.inventory = new List<string>();
            return gs;
        }

        public class GameState {
            public string current;
            public List<string> inventory;
        }
    }
}
