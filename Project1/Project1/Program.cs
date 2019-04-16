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
            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("A - buy a sword for 10gp");
            Console.WriteLine("B - buy a bow for 7gp");
            Console.WriteLine("C - buy an arrow for 1gp");
            Console.WriteLine("D - buy a lockpicking kit for 2gp");
            Console.WriteLine("E - buy a pair of binoculars for 2gp");
            Console.WriteLine("F - buy a bottle of the smith's 'rum' for 8gp");
            Console.WriteLine("G - set out for sharnwick");

            string input;
            do {
                input = Console.ReadLine().ToLower();
                switch (input) {
                    case "a":
                        Console.WriteLine("You bought the sword");
                        gs.inventory.Add("sword");
                        break;
                    case "b":
                        Console.WriteLine("You bought the bow");
                        gs.inventory.Add("bow");
                        break;
                    case "c":
                        Console.WriteLine("You bought the arrow");
                        gs.inventory.Add("arrow");
                        break;
                    case "d":
                        Console.WriteLine("You bought the lockpicking kit");
                        gs.inventory.Add("lockpicking kit");
                        break;
                    case "e":
                        Console.WriteLine("You bought the binoculars");
                        gs.inventory.Add("binoculars");
                        break;
                    case "f":
                        Console.WriteLine("You bought the 'rum'");
                        gs.inventory.Add("rum");
                        break;
                    case "g":
                        Console.WriteLine("You set out to sharnwick");
                        gs.current = "sharnwick";
                        break;
                }
            } while (input.Count() == 1 && input[0] >= 'a' && input[0] <= 'g');
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
