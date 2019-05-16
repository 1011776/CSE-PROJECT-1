using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1 {
    class Program {

        // Apart from the switch statement, main should remain the same regardless of new features added
        // New features and areas should be added as functions and included in the switch statement
        static void Main(string[] args) {
            GameState gs = NewGame();
            while (gs.current != "quit") {
                // gs.current contains a string thar corresponds to a function
                switch (gs.current) {
                    case "menu": Menu(gs); break;
                    case "about": About(gs); break;
                    case "inn": Inn(gs); break;
                    case "chadford": Chadford(gs); break;
                    case "letter": Letter(gs); break;
                    case "armoury": Armoury(gs); break;
                    case "dead horse": DeadHorse(gs); break;
                    case "sharnwick": Sharnwick(gs); break;
                    case "hideout": Hideout(gs); break;
                    case "captured": Captured(gs); break;
                    case "win": Win(gs); break;
                    case "lose": Lose(gs); break;
                    default:
                        Console.WriteLine("An unexpected error has occured.");
                        Console.WriteLine("gs.current is an invalid value.");
                        Console.WriteLine("The software will now quit.");
                        Console.WriteLine("Press any key to continue.");
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
            Console.WriteLine("The Smith's Stash");
            Console.WriteLine("By Alistair Parkinson");
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
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
            Console.WriteLine();
            gs.current = "menu";
        }

        // Accessed from "win", "lose" and "menu"
        // Describes main character being kicked out of an inn and recieving a letter
        static void Inn(GameState gs) {
            if (HasBeenTo(gs, "inn")) {
                Console.WriteLine("You re-enter the inn. The innkeeper is looking at you confused. \"I thought you were broke?\" " +
                    "he said.");
                if (gs.gp == 0) {
                    Console.WriteLine("You reach into your pockets to see if still have any gold pieces. Your pockets are empty. " +
                        "You turn around and walk out of the inn forgetting what made you go back in the first place");
                } else {
                    Console.WriteLine("Reaching into your pocket you pull out the few gold pieces you have left. You pull out " +
                        gs.gp + "gp and hand it to the . The inkeeper gives you another look and hands you your pieces back. " +
                        "\"Thats not even close to enough\" he says. You decide to leave the inn, perhaps you'll come back when you've" +
                        "earned enough.");
                }
            } else {
                Console.WriteLine("You hand your keys over to the innkeeper. You’ll need find somewhere else to stay. " +
                    "Just as you exit the door the innkeeper reminds you \"Your friend Baern left a message for you, " +
                    "take this\", the innkeeper hands you a letter.");
            }
            gs.inventory.Add("chadford");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
            gs.current = "chadford";
        }

        // Accessed from "inn"
        // Describes the main character opening the letter thay recieved from the inn
        static void Letter(GameState gs) {
            const string NAME = "Bilbo";
            Console.WriteLine("Opening the letter you read:\n Dear " + NAME + ",\n I'm writing this to let you know that " +
                "I am on my way to the settlement of Sharnwick, and I think I've uncovered something big. " +
                "If you're looking for work I'd reccomend you come down as I'll need someone to help me with the project.");
            Console.WriteLine("P.S. I'm sure you already know, but the trails to Sharnwick are notoriuos for being " +
                "dangerous, so I suggest you get something from the armoury");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            gs.current = "chadford";
        }

        // Accessed from "inn" and "letter"
        static void Chadford(GameState gs) {
            Console.WriteLine("You are standing outside the inn, at one of the busy streets of the city of Chadford. " +
                "You are currently holding the letter that you had recieved from the innkeeper. Across the street is " +
                "an armoury, and further down the street is a road that goes leads to the settlement of Sharnwick.");
            if (HasBeenTo(gs, "letter") && !HasBeenTo(gs, "armoury")) {
                Console.WriteLine("You think about what Baern told you about the road to Sharnwick being dangerous " +
                    "and you have a gut feeling that you should follow his advice and take a visit to the armoury.");
            }
            if (HasBeenTo(gs, "armoury") && gs.gp < 10) {
                Console.WriteLine("Now that you've bought what you need from the armoury, your feeling more prepared " +
                    "to take on the world.");
            }
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Visit the armoury",
                "Read your letter",
                "Revisit the inn"
            };
            if (HasBeenTo(gs, "letter")) {
                options.Add("Set out to Sharnwick");
            }
            switch (options[PresentOptions(options, message)]) {
                case "Set out to Sharnwick":
                    gs.current = "dead horse";
                    break;
                case "Visit the armoury":
                    gs.current = "armoury";
                    break;
                case "Read your letter":
                    gs.current = "letter";
                    break;
                case "Revisit the inn":
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
                "Exit the armoury"
            };

            if (HasBeenTo(gs, "armoury") == false) {
                Console.WriteLine("The armoury is a small shop which you haven't been inside before." +
                    "On the inside is an weathered iron anvil, furnace and a workbench. Layed out across " +
                    "the workbench is a vast array of different items. The blacksmith sits behind a counter, " +
                    "putting final touches on the decorated spoon he had been working on using a oiled rag. " +
                    "He is an old looking man with a bald head and long black beard. " +
                    "He asks if you are looking for anything.");
            } else {
                Console.WriteLine("The blacksmith sits behind a counter. He is still rubbing the spoon with " +
                    "the oiled rag. He stops for a second and asks if you are looking for anything.");
            }

            Console.WriteLine("You currently have " + gs.gp + "gp.");

            switch (PresentOptions(options, message)) {
                case 0:
                    Buy(gs, "sword", 10);
                    break;
                case 1:
                    Buy(gs, "bow", 7);
                    break;
                case 2:
                    Buy(gs, "arrow", 1);
                    break;
                case 3:
                    Buy(gs, "lockpicking kit", 2);
                    break;
                case 4:
                    Buy(gs, "binoculars", 2);
                    break;
                case 5:
                    Buy(gs, "rum", 8);
                    break;
                case 6:
                    Console.WriteLine("You walk out the armoury.");
                    gs.current = "chadford";
                    break;
            }
        }

        // Accessed from "letter" and "inn"
        // The main character stumbles across a dead horse on the way to Sharnwick, they are attacked by goblins
        static void DeadHorse(GameState gs) {
            switch (gs.last) {
                case "chadford":
                    Console.WriteLine("You set off to Sharnwick. After about half a day of travel, as you come around a bend, " +
                    "you spot a dead horse sprawled about twenty meters ahead of you, blocking the path. Several " +
                    "black-feathered arrows stick out of it. The woods press close to the trail here, with a steep embankment " +
                    "and dense thickets on either side.");
                    break;
                case "sharnwick":
                    Console.WriteLine("On your way back to Chadford, you stumble across the same dead horse you saw on the way " +
                        "there. It is still there, sprawled accross the ground and blocking the path, with several black-feathered " +
                        "arrows sticking out of it. The woods press close to the trail here, with a steep embankment " + 
                        "and dense thickets on either side.");
                    break;
            }
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Head to Chadford",
                "Head to Sharnwick"
            };
            switch (options[PresentOptions(options, message)]) {
                case "Head to Sharnwick":
                    switch (gs.last) {
                        case "chadford":
                            Console.WriteLine("You decide that its better to head back to Sharnwick. You turn around and walk back the way " +
                                "you came.");
                            break;
                        case "sharnwick":
                            Console.WriteLine("You ignore the dead horse, stepping over it, and walk the rest of the way to Sharnwick.");
                            break;
                    }
                    gs.current = "sharnwick";
                    break;
                case "Head to Chadford":
                    switch (gs.last) {
                        case "sharnwick":
                            Console.WriteLine("You decide that its better to head back to Chadford. You turn around and walk back the way " +
                                "you came.");
                            break;
                        case "chadford":
                            Console.WriteLine("You ignore the dead horse, stepping over it, and walk the rest of the way to Chadford.");
                            break;
                    }
                    gs.current = "sharnwick";
                    break;
            }
        }

        // Accessed from "dead horse"
        // Baern is nowhere to be found in sharnwick and must back to search for him
        static void Sharnwick(GameState gs) {
            Console.WriteLine("After another few hours in the distance you spot the small town of Sharnwick. Theres a inn, shops and " +
                "a chapel. It isn't as big of a town as Chadford, so it doesn't take you long to visit all of the shops and houses. " +
                "After looking around the town, you realise that you can't find Baern. Perhaps he's somewhere back in Chadford.");
            Console.WriteLine("You decide, as there is nothing else to do, to turn back and head back to Chadford.");
            Console.ReadKey();
        }

        // Accessed from multiple functions
        // If the player chooses to drink the rum they die from poisoning
        static void Rum(GameState gs) {
            Console.WriteLine("The rum is an opaque looking liquid... if you could call it one. You pop the cork off, and " +
                "a noxious smelling gas wafts from the lid. Trying not gag you take a sip from the bottle. You start to " +
                "feel dizzy, and then tingling coming from all over your body. Your vision becomes blurry and you drop the " +
                "bottle to the floor, causing it to shatter into hundreds of pieces. You fall over and and are knocked out " +
                "unconcious.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            gs.current = "lose";
        }

        // Accessed from "dead horse"
        // The main character has snuck into the goblin's hideout
        static void Hideout(GameState gs) {

        }

        // Accessed from "desd horse"
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

        // Updates gs.beenTo to contain the last value that current was
        static void UpdateBeenTo(GameState gs) {
            if (HasBeenTo(gs, gs.cache) == false) {
                gs.beenTo.Add(gs.cache);
            }
            string oldCache = gs.cache;
            gs.cache = gs.current;
            gs.last = oldCache;
        }

        // Prints appropriate message when player attempts to buy item
        // Item is added to inventory of player only if they have enough gold
        // Gold is deducted depending on the cost of the item
        static void Buy(GameState gs, string item, int cost) {
            if (gs.gp >= cost) {
                Console.WriteLine("You bought the " + item);
                gs.inventory.Add(item);
                gs.gp -= cost;
            } else {
                Console.WriteLine("You cannot afford that");
            }
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
            gs.last = "menu";
            return gs;
        }

        // Contains all information about the player and the environment
        public class GameState {
            // Contains string that corresponds to a the next function that needs to be called
            // Read by main and written to by functions outside main 
            public string current;
            // Contains list of all items the player is holding
            public List<string> inventory;
            // Gold pieces or gp is the currency of the world of the game
            // Contains number based on how many gold pieces the player is carrying
            public int gp;
            // Only written to by UpdateBeenTo
            // Contains list of all values that current has been except for what it currently is
            // It is reccomended that HasBeenTo is called rather than accessing the beenTo variable 
            public List<string> beenTo;
            // Only accessed by UpdateBeenTo
            // Contains last value that current was, unless updateBeenTo has been called before current is modified
            // It is not reccomended that this variable is not accessed by functions apart from UpdateBeenTo
            public string cache;
            // Written to by UpdateBeenTo
            // Contains last value that current was. Unless current has been written to before UpdateBeenTo has been called
            public string last;
        }
    }
}