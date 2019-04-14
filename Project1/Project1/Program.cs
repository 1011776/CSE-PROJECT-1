using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
    class Program {
        static void Main(string[] args) {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
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
            gs.inventory = new List<string>();
            return gs;
        }

        public class GameState {
            public List<string> inventory;
        }
    }
}
