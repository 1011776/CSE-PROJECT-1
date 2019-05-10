using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1 {
    class Program {

        // NOTE
        // Apart from the switch statement, main should remain the same regardless of new features added
        // New features and areas should be added as functions and included in the switch statement
        static void Main(string[] args) {
            GameState gs = NewGame();
            while (gs.current != "quit") {
                // gs.current contains a string thar corresponds to a function
                switch (gs.current) {
                    case "menu":        Menu(gs);       break;
                    case "about":       About(gs);      break;
                    case "inn":         Inn(gs);        break;
                    case "letter":      Letter(gs);     break;
                    case "armoury":     Armoury(gs);    break;
                    case "dead horses": DeadHorses(gs); break;
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
                UpdateBeenTo(gs);
                Console.WriteLine();
            }
        }

        // First function that runs when application is ran 
        // Prints title screen shows user with options to start a new game and view about screen
        static void Menu(GameState gs) {
            Console.WriteLine("The Smith's stash");
            string message = "Choose an option.";
            List<string> options = new List<string>() {
                "Play Game",
                "About",
                "Quit"
            };
            int input = PresentOptions(options, message);
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

        // Accessed from "menu"
        // Gives brief summary of what game is about
        static void About(GameState gs) {
            Console.WriteLine("About Menu");
            Console.WriteLine("The Smith's Stash, written by Alistair Parkinson, is a text adventure as a part of a " +
                "school project. This game is open-source, so feel free to use my code as per the MIT Licence. " +
                "Currently this project is still in development so expect regular updates. I hope you enjoy my game.");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            gs.current = "menu";
        }

        // Accessed from "win", "lose" and "menu"
        // Describes main character being kicked out of an inn and recieving a letter
        static void Inn(GameState gs) {
            Console.WriteLine("You hand your keys over to the innkeeper. You’ll need find somewhere else to stay. " +
                "Just as you exit the door the innkeeper reminds you \"Your friend Baern left a message for you, " + 
                "take this\", the innkeeper hands you a letter");
            gs.inventory.Add("letter");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            gs.current = "letter";
        }

        // Accessed from "inn"
        // Describes the main character opening the letter thay recieved from the inn
        static void Letter(GameState gs) {
            const string NAME = "Bilbo";
            Console.WriteLine("Opening the letter you read:\n Dear " + NAME + ",\n I'm writing this to let you know that " +
                "I am on my way to the settlement of Sharnwick, and I think I've uncovered something big. " +
                "If you're looking for work I'd reccomend you come down as I'll need someone to help me with the project.\n" +
                "P.S. the trails to Sharnwick are notoriuos for being dangerous, so I suggest you get something from the armoury");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Set out to sharnwick",
                "Visit the armory",
                "Revisit the inn"
            };
            switch (PresentOptions(options, message)) {
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

        // Accessed from "letter"
        // The main character visits the armoury and can purchase adventuring gear for gold pieces
        static void Armoury(GameState gs) {
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Buy a sword for 10gp",
                "Buy a bow for 7gp",
                "Buy an arrow for 1gp",
                "Buy a lockpicking kit for 2gp",
                "Buy a pair of binoculars for 2gp",
                "Buy a bottle of the smith's 'rum' for 8gp",
                "Set out for sharnwick"
            };

            if (HasBeenTo(gs, "armoury") == false) {
                Console.WriteLine("The armoury is a small, old looking shop. The blacksmith is an old looking man" +
                    "at the counter is a vast array of different items. You reach into your pocket and pull out " +
                    "the rest of the money you have left.");
            }

            Console.WriteLine("You currently have ", gs.gp, " gp");

            switch (PresentOptions(options, message)) {
                case 0:
                    if (gs.gp >= 10) {
                        Console.WriteLine("You bought the sword");
                        gs.inventory.Add("sword");
                        gs.gp -= 10;
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 1:
                    if (gs.gp >= 7) {
                        Console.WriteLine("You bought the bow");
                        gs.inventory.Add("bow");
                        gs.gp -= 7;
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 2:
                    if (gs.gp >= 1) {
                        Console.WriteLine("You bought the arrow");
                        gs.inventory.Add("arrow");
                        gs.gp -= 1;
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 3:
                    if (gs.gp >= 2) {
                        Console.WriteLine("You bought the lockpicking kit");
                        gs.inventory.Add("lockpicking kit");
                        gs.gp -= 2;
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 4:
                    if (gs.gp >= 2) {
                        Console.WriteLine("You bought the binoculars");
                        gs.inventory.Add("binoculars");
                        gs.gp -= 2;
                    } else {
                        Console.WriteLine("You cannot afford that");
                    }
                    break;
                case 5:
                    if (gs.gp >= 8) {
                        Console.WriteLine("You bought the 'rum'");
                        gs.inventory.Add("rum");
                        gs.gp -= 8;
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

        // Accessed from "letter" and "inn"
        // The main character stumbles across a dead horse on the way to Sharnwick, they are attacked by goblins
        static void DeadHorses(GameState gs) {
            Console.WriteLine("You set off to sharnwick. After about half a day of travel, as you come around a bend, " +
                "you spot a dead horse sprawled about fifty feet ahead of you is, blocking the path. It several " +
                "black-feathered arrows sticking out of it. The woods press close to the trail here, with a steep embankment " +
                "and dense thickets on either side.");

            

            Console.ReadKey();
        }

        // Accessed from "dead horses"
        // Baern is nowhere to be found in sharnwick and must back to search for him
        static void Sharnwick(GameState gs) {
            Console.WriteLine("After another few hours in the distance you spot the small town of Sharnwick. Theres a inn, shops, " +
                "a chapel, but no Baern. You think to yourself \" maybe he's still hasn't left Bardford\".");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Head back to Bardford"
            };
            int input = PresentOptions(options, message);
            switch (input) {
                case 0:
                    gs.current = "ambush";
                    break;
            }
            Console.ReadKey();
        }

        // Accessed from "dead horses"
        // The main character has snuck into the goblin's hideout
        static void Hideout(GameState gs) {

        }

        // Accessed from "desd horses"
        // The main character is captured by the goblin ambushers
        static void Captured(GameState gs) {

        }

        // Accessed when the player wins the game
        // Lets player know that they have won the game, gives the player option to play again or quit
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

        // Accessed when the player loses the game
        // Lets player know that they have lost the game, gives the player option to play again or quit
        static void Lose(GameState gs) {
            Console.WriteLine("You have lost the game");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Try again",
                "Quit"
            };
            switch (PresentOptions(options, message)) {
                case 0:
                    gs.current = "inn";
                    gs = NewGame();
                    break;
                case 1:
                    gs.current = "quit";
                    break;
            }
        }

        // Returns whether the gs.inventory contains item using linear search algorithm
        static bool HasItem(GameState gs, string item) {
            for (int i = 0; i < gs.inventory.Count(); i++) {
                if (item == gs.inventory[i]) {
                    return true;
                }
            }
            return false;
        }

        // Returns whether the gs.beenTo contains section using linear search algorithm
        static bool HasBeenTo(GameState gs, string section) {
            for (int i = 0; i < gs.beenTo.Count(); i++) {
                if (section == gs.beenTo[i]) {
                    return true;
                }
            }
            return false;
        }

        static void UpdateBeenTo (GameState gs) {
            gs.beenTo.Add(gs.current);
        }

        // Prints out options and prompts user to select one, message is printed with options presented
        static int PresentOptions(List<string> options, string message) {
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

        // Returns the GameSate for a default start from the beginning of the game
        static GameState NewGame() {
            GameState gs = new GameState();
            gs.current = "menu";
            gs.beenTo = new List<string>() { "menu" };
            gs.inventory = new List<string>();
            gs.gp = 10;
            return gs;
        }

        // Contains all information about the player and the environment
        public class GameState {
            public string current;
            public List<string> inventory;
            public int gp;
            public List<string> beenTo;
        }
    }
}
