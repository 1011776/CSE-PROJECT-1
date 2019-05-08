using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1 {
    class Program {
        static void Main(string[] args) {
            GameState gs = NewGame();
            while (gs.current != "quit") {
                switch (gs.current) {
                    case "menu":        Menu(gs);       break;
                    case "about":       About(gs);      break;
                    case "inn":         Inn(gs);        break;
                    case "letter":      Letter(gs);     break;
                    case "armoury":     Armoury(gs);    break;
                    case "ambush":      Ambush(gs);     break;
                    case "sharnwick":   Sharnwick(gs);  break;
                    case "hideout":     Hideout(gs);    break;
                    case "captured":    Captured(gs);   break;
                    case "win":         Win(gs);        break;
                    case "lose":        Lose(gs);       break;
                    default:
                        Console.WriteLine("An unexpected error has occured, the software will now quit");
                        Console.ReadKey();
                        gs.current = "quit";
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Menu(GameState gs) {
            Console.WriteLine("The Smith's stash");
            string message = "Choose an option.";
            List<string> options = new List<string>() {
                "Play Game",
                "About",
                "Quit"
            };
            int input = presentOptions(options, message);
            switch (input) {
                case 0:
                    gs.current = "inn";
                    break;
                case 1:
                    gs.current = "about";
                    break;
                case 2:
                    gs.current = "quit";
                    break;
            }
        }

        static void About(GameState gs) {
            Console.WriteLine("About Menu");
            Console.WriteLine("The Smith's Stash, written by Alistair Parkinson, is a text adventure as a part of a " +
                "school project. This game is open-source, so feel free to use my code as per the MIT Licence. " +
                "Currently this project is still in development so expect regular updates. I hope you enjoy my game.");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            gs.current = "menu";
        }

        static void Inn(GameState gs) {
            Console.WriteLine("You hand your keys over to the innkeeper. You’ll need find somewhere else to stay. " +
                "Just as you exit the door the innkeeper reminds you \"Your friend Baern left a message for you, " + 
                "take this\", the innkeeper hands you a letter");
            gs.inventory.Add("letter");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            gs.current = "letter";
        }
        static void Letter(GameState gs) {
            const string NAME = "Bilbo";
            Console.WriteLine("Opening the letter you read:\n Dear " + NAME + ",\n I'm writing this to let you know that " +
                "I am on my way to the settlement of Sharnwick, and I think I've uncovered something big. " +
                "If you're looking for work I'd reccomend you come down as I'll need someone to help me with the project.\n" +
                "P.S. the trails to Sharnwick are notoriuos for being dangerous, so I suggest you get something from the armoury");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "set out to sharnwick",
                "visit the armory",
                "revisit the inn"
            };
            switch (presentOptions(options, message)) {
                case 0:
                    gs.current = "ambush";
                    break;
                case 1:
                    gs.current = "armoury";
                    break;
                case 2:
                    gs.current = "inn";
                    break;
            }
        }
        static void Armoury(GameState gs) {
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "buy a sword for 10gp",
                "buy a bow for 7gp",
                "buy an arrow for 1gp",
                "buy a lockpicking kit for 2gp",
                "buy a pair of binoculars for 2gp",
                "buy a bottle of the smith's 'rum' for 8gp",
                "set out for sharnwick"
            };

            switch (presentOptions(options, message)) {
                case 0:
                    if (gs.gp >= 10) {
                        Console.WriteLine("You bought the sword");
                        gs.inventory.Add("sword");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 1:
                    if (gs.gp >= 7) {
                        Console.WriteLine("You bought the bow");
                        gs.inventory.Add("bow");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 2:
                    if (gs.gp >= 1) {
                        Console.WriteLine("You bought the arrow");
                        gs.inventory.Add("arrow");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 3:
                    if (gs.gp >= 2) {
                        Console.WriteLine("You bought the lockpicking kit");
                        gs.inventory.Add("lockpicking kit");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 4:
                    if (gs.gp >= 2) {
                        Console.WriteLine("You bought the binoculars");
                        gs.inventory.Add("binoculars");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 5:
                    if (gs.gp >= 8) {
                        Console.WriteLine("You bought the 'rum'");
                        gs.inventory.Add("rum");
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 6:
                    Console.WriteLine("You set out to sharnwick");
                    gs.current = "sharnwick";
                    break;
            }
        }

        static void Ambush(GameState gs) {
            Console.WriteLine("You set off to sharnwick. After about half a day of travel, as you come around a bend, " +
                "you spot a dead horse sprawled about fifty feet ahead of you is, blocking the path. It several " +
                "black-feathered arrows sticking out of it. The woods press close to the trail here, with a steep embankment " +
                "and dense thickets on either side.");

            Console.ReadKey();
        }

        static void Sharnwick(GameState gs) {
            Console.WriteLine("After another few hours in the distance you spot the small town of Sharnwick. Theres a inn, shops, " +
                "a chapel, but no Baern. You think to yourself \" maybe he's still hasn't left Bardford\".");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Head back to Bardford"
            };
            int input = presentOptions(options, message);
            switch (input) {
                case 0:
                    gs.current = "ambush";
                    break;
            }
            Console.ReadKey();
        }

        static void Hideout(GameState gs) {

        }

        static void Captured(GameState gs) {

        }

        static void Win(GameState gs) {
            Console.WriteLine("You have won the game");
            string input;
            do {
                Console.WriteLine("What do you do next?");
                Console.WriteLine("A - Try again");
                Console.WriteLine("B - Quit");
                input = Console.ReadLine().ToLower();
            } while (input.Count() == 1 && input[0] >= 'a' && input[0] <= 'b');
            switch(input) {
                case "a":
                    gs.current = "inn";
                    gs = NewGame();
                    break;
                case "b":
                    gs.current = "quit";
                    break;
            }
        }

        static void Lose(GameState gs) {
            Console.WriteLine("You have lost the game");
            string input;
            do {
                Console.WriteLine("What do you do next?");
                Console.WriteLine("A - Try again");
                Console.WriteLine("B - Quit");
                input = Console.ReadLine().ToLower();
            } while (input.Count() == 1 && input[0] >= 'a' && input[0] <= 'b');
            switch (input) {
                case "a":
                    gs.current = "inn";
                    gs = NewGame();
                    break;
                case "b":
                    gs.current = "quit";
                    break;
            }
        }

        static bool HasItem(GameState gs, string item) {
            for (int i = 0; i < gs.inventory.Count(); i++) {
                if (item == gs.inventory[i]) {
                    return true;
                }
            }
            return false;
        }

        static int presentOptions(List<string> options, string message) {
            Console.WriteLine();
            string choice = "";
            do {
                Console.WriteLine(message);
                for (int i = 0; i < options.Count(); i++) {
                    Console.WriteLine((char)('A' + i) + " - " + options[i]);
                }
                choice = Console.ReadLine().ToUpper();
            } while (choice.Count() != 1 || choice[0] < 'A' || choice[0] >= 'A' + options.Count());
            return choice[0] - 'A';
        }

        static GameState NewGame() {
            GameState gs = new GameState();
            gs.current = "menu";
            gs.inventory = new List<string>();
            gs.gp = 10;
            return gs;
        }

        public class GameState {
            public string current;
            public List<string> inventory;
            public int gp;
        }
    }
}
