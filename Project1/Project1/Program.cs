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
                    case "menu":        Menu(gs);       break;
                    case "about":       About(gs);      break;
                    case "inn":         Inn(gs);        break;
                    case "chadford":    Chadford(gs);   break;
                    case "letter":      Letter(gs);     break;
                    case "armoury":     Armoury(gs);    break;
                    case "dead horse":  DeadHorse(gs);  break;
                    case "sneak":       Sneak(gs);      break;
                    case "attack":      Attack(gs);     break;
                    case "inspect":     Inspect(gs);    break;
                    case "surrounds":   Surrounds(gs);  break;
                    case "ambushed":    Ambushed(gs);   break;
                    case "sharnwick":   Sharnwick(gs);  break;
                    case "hideout":     Hideout(gs);    break;
                    case "escape":      Escape(gs);     break;
                    case "rum guard":   RumGuard(gs);   break;
                    case "rum":         Rum(gs);        break;
                    case "captured":    Captured(gs);   break;
                    case "win":         Win(gs);        break;
                    case "lose":        Lose(gs);       break;
                    default:
                        Console.WriteLine("An unexpected error has occurred.");
                        Console.WriteLine("gs.current =" + gs.current + " and is an invalid value.");
                        Console.WriteLine("The software will now quit.");
                        Pause();
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
            Console.WriteLine();
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
            Pause();
            gs.current = "menu";
        }

        // Accessed from "win", "lose" and "menu"
        // Describes main character being kicked out of an inn and recieving a letter
        // Regardless of player decisions, function accesses "charnford"
        static void Inn(GameState gs) {
            if (HasBeenTo(gs, "inn")) {
                Console.WriteLine("You re-enter the inn. The innkeeper is looking at you confused. \"I thought you were broke?\" " +
                    "he said.");
                Pause();
                if (gs.gp == 0) {
                    Console.WriteLine("You reach into your pockets to see if still have any gold pieces. Your pockets are empty. ");
                    Pause();
                    Console.WriteLine("You turn around and walk out of the inn forgetting what made you go back in the first place");
                } else {
                    Console.WriteLine("Reaching into your pocket you pull out the few gold pieces you have left. You pull out " +
                        gs.gp + "gp and hand it to the innkeeper.");
                    Pause();
                    Console.WriteLine("The inkeeper gives you another look and hands you the gold pieces back. " +
                        "\"Thats not even close to enough\" he says. You decide to leave the inn, perhaps you'll come back when you've" +
                        "earned enough.");
                }
            } else {
                Console.WriteLine("You hand your keys over to the innkeeper. You’ll need find somewhere else to stay. ");
                Pause();
                Console.WriteLine("Just as you exit the door the innkeeper reminds you \"Your friend Baern left a message for you, " +
                    "take this\", the innkeeper hands you a letter.");
            }
            gs.inventory.Add("chadford");
            Pause();
            gs.current = "chadford";
        }

        // Accessed from "inn"
        // Describes the main character opening the letter thay received from the inn
        // Regardless of player decisions, function accesses "charnford"
        static void Letter(GameState gs) {
            const string NAME = "Bilbo";
            Console.WriteLine("Opening the letter you read:\n Dear " + NAME + ",\n I'm writing this to let you know that " +
                "I am on my way to the settlement of Sharnwick, and I think I've uncovered something big. ");
            Pause();
            Console.WriteLine("If you're looking for work I'd reccomend you come down as I'll need someone to help me with the project.");
            Pause();
            Console.WriteLine("P.S. I'm sure you already know, but the trails to Sharnwick are notoriuos for being " +
                "dangerous, so I suggest you get something from the armoury");
            Pause();
            gs.current = "chadford";
        }

        // Accessed from "inn" and "letter"
        static void Chadford(GameState gs) {
            Console.WriteLine("You are standing outside the inn, at one of the busy streets of the city of Chadford. " +
                "You are currently holding the letter that you had received from the innkeeper. Across the street is " +
                "an armoury, and further down the street is a road that leads to the settlement of Sharnwick.");
            if (HasBeenTo(gs, "letter") && !HasBeenTo(gs, "armoury")) {
                Pause();
                Console.WriteLine("You think about what Baern told you about the road to Sharnwick being dangerous " +
                    "and you have a gut feeling that you should follow his advice and take a visit to the armoury.");
            }
            if (HasBeenTo(gs, "armoury") && gs.gp < 10) {
                Pause();
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
            if (HasItem(gs, "rum")) {
                options.Add("Drink the rum");
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
                case "Drink the rum":
                    gs.current = "rum";
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
                    "the workbench is a vast array of different items.");
                    
                Console.WriteLine("The blacksmith sits behind a counter, " +
                    "putting final touches on the decorated spoon he had been working on using a oiled rag. " +
                    "He is an old looking man with a bald head and long black beard. " +
                    "He asks if you are looking for anything.");
            } else {
                Console.WriteLine("The blacksmith sits behind a counter. He is still rubbing the spoon with " +
                    "the oiled rag. He stops for a second and asks if you are looking for anything.");
            }
            Pause();
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

        // Accessed from "chadwick" and "surrounds"
        // The main character stumbles across a dead horse on the way to Sharnwick, they are attacked by goblins
        static void DeadHorse(GameState gs) {
            switch (gs.last) {
                case "chadford":
                    Console.WriteLine("You set off to Sharnwick. After about half a day of travel, as you come around a bend, " +
                    "you spot a dead horse sprawled across the path, about twenty meters ahead of you. Several " +
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
                "Have a closer look at the horse",
                "Call out to see if anyone is around",
                "Have a closer look at your surroundings",
                "Head to Sharnwick"
            };
            if (HasItem(gs, "rum")) {
                options.Add("Drink the rum");
            }
            if (gs.spottedGoblins) {
                options.Add("Wait and stay out of sight of the goblins");
                options.Add("Try to sneak attack the goblins");
            }
            switch (options[PresentOptions(options, message)]) {
                case "Head to Sharnwick":
                    switch (gs.last) {
                        case "sharnwick":
                            Console.WriteLine("You decide that its better to head back to Sharnwick. You turn around and walk back the way " +
                                "you came.");
                            break;
                        case "chadford":
                            Console.WriteLine("You ignore the dead horse, stepping over it, and walk the rest of the way to Sharnwick.");
                            break;
                    }
                    Pause();
                    gs.current = "sharnwick";
                    break;
                case "Call out to see if anyone is around":
                    Console.WriteLine("You shout out \"Is anyone around\", there was no response. You do it again, but again, there was no " +
                        "response.");
                    Pause();
                    gs.current = "ambushed";
                    break;
                case "Have a closer look at the horse":
                    gs.current = "inspect";
                    break;
                case "Head to Chadford":
                    switch (gs.last) {
                        case "chadford":
                            Console.WriteLine("You decide that its better to head back to Chadford. You turn around and walk back the way " +
                                "you came.");
                            break;
                        case "sharnwick":
                            Console.WriteLine("You ignore the dead horse, stepping over it, and walk the rest of the way to Chadford.");
                            break;
                    }
                    Pause();
                    gs.current = "chadford";
                    break;
                case "Have a closer look at your surroundings":
                    gs.current = "surrounds";
                    break;
                case "Drink the rum":
                    gs.current = "rum";
                    break;
                case "Wait and stay out of sight of the goblins":
                    gs.current = "sneak";
                    break;
                case "Try to sneak attack the goblins":
                    gs.current = "attack";
                    break;
            }
        }

        // Accessed from "dead horse"
        // The main character, waits for the goblins to leave and then follows them back to their hideout
        // Regardless of player decisions, function accesses "hideout"
        static void Sneak(GameState gs) {
            Console.WriteLine("You find a hiding spot behind a rock, where you can still see the goblins. You sit there watching them as to see " +
                "what they do");
            Pause();
            Console.WriteLine("After about half an hour, the goblins get up and head down a concealed trail at the side of the road.");
            Pause();
            Console.WriteLine("You choose to keep them in sight, tailing them so that they don't notice you.");
            Pause();
            gs.current = "hideout";
        }

        // Accessed from "dead horse"
        // The main character, attemps to sneak attack the goblins
        static void Attack(GameState gs) {
            if (HasItem(gs, "bow") && HasItem(gs, "arrow")) {
                Console.WriteLine("From behind a tree, you fire an arrow at one of the goblins.");
                Pause();
                Console.WriteLine("The goblins noticed that one of them had been shot, but not noticed the direction in which the arrow " +
                    "came from. Driven by fear, the two goblins run down a a concealed trail by the side of the road.");
                Pause();
                Console.WriteLine("Curious as to know what they were doing hiding by the side of the road, you choose to follow them, making sure " +
                    "that you keep your distance between them as to not be noticed.");
                Pause();
                gs.current = "hideout";
            } else {
                Console.WriteLine("You are unarmed.");
                switch(PresentOptions(new List<string>() { "Yes", "No" }, "Are you sure you want to do this?")) {
                    case 0:
                        Console.WriteLine("Trying to be stealthy you sneak up behind the group of goblins. You ready your fists, and then " +
                            "punch one of the goblins.");
                        Pause();
                        Console.WriteLine("The goblin that got punched falls to the ground. The other two goblins notice, and they both shoot " +
                            "an arrow at you. One of them narrowly misses you, but the other one hits you in the chest");
                        Pause();
                        gs.current = "lose";
                        break;
                    case 1:
                        Console.WriteLine("You decide its best not to engage with a fight against the goblins without weapons.");
                        Pause();
                        break;
                }
            }
        }

        // Accessed from "dead horse"
        // The main character, either with or without binoculars, inspects their surroundings
        // If the main character has binoculars they spot the goblins otherwise the main character has a feeling of being watched
        static void Surrounds(GameState gs) {
            Console.WriteLine("You scan the trees and bushes surrounding you.");
            Pause();
            if (HasItem(gs, "binoculars")) {
                Console.WriteLine("At first you don't see anything, but then you pull out your binoculars and have another look.");
                Pause();
                Console.WriteLine("Through your binoculars, you spot three goblins crouching behind a bush. They are armed with bows. " +
                    "However they don't seem to have spotted you.");
                gs.spottedGoblins = true;
            } else {
                Console.WriteLine("You don't see anything but you get the feeling that you are being watched.");
            }
            gs.current = "dead horse";
        }

        // Accessed from "dead horse"
        // The main characters has a closer inspection of the dead horse and notices that the horse belongs to Baern.
        // Regardless of player decisions, function accesses "ambushed"
        static void Inspect(GameState gs) {
            Console.WriteLine("You approach the dead horse on the path, and kneel down beside it. The horse seems to have been shot recently, " +
                "perhaps within the past twenty-four hours. You notice that the saddlebags are empty, you guess they must have been looted.");
            Pause();
            Console.WriteLine("As you step away from the horse, a small metal compass hald burried in the dirt of the track. " +
                "You pick it up, turning it around you notice a name engraved in the back: \"Baern\".");
            Pause();
            gs.current = "ambushed";
        }

        // Accessed from "dead horse"
        // Three goblins have gotten the jump on the main character and the player is captured
        static void Ambushed(GameState gs) {
            Console.WriteLine("Suddenly from out of nowhere an arrow narrowly misses your head and plants itself into a tree next to you. " +
                        "Looking at the arrow, it has the same black feathers that you saw sticking out of the horse. You turn to look at where the " +
                        "arrow came from. Standing behind a shrub about twenty meters away, are three goblins with their bows and arrows pointed at you.");
            string message = "what do you do next?";
            List<string> options = new List<string> { "Try to run from the goblins", "Try to attack the goblins", "Put your hands up and stay still" };
            switch (PresentOptions(options, message)) {
                case 0:
                    Console.WriteLine("You turn around and try to make a run from the goblins. One of the goblins fire an arrow at you " +
                        "and it hits you back, dealing a lethal blow to you.");
                    gs.current = "lose";
                    break;
                case 1:
                    if (HasItem(gs, "sword")) {
                        Console.WriteLine("You draw your sword and charge at the goblins. The goblins do not hesitate to react. One fires a arrow at " +
                            "you, you swing your sword in an attempt to deflect it, but you miss. The arrow hits you in the chest.");
                    } else if (HasItem(gs, "bow") && HasItem(gs, "arrow")) {
                        Console.WriteLine("You draw your bow, knock an arrow into it, and fire a shot in the direction of the goblins. Due to it " +
                            "being the first time you had weilded a bow and being under pressure, you completely miss. The goblins do not hesitate " +
                            "to react. One goblin fires an arrow at you which hits you in the chest.");
                    } else {
                        Console.WriteLine("Despite being unarmed, you charge at the goblins. The goblins do not hesitate to react." +
                            "One goblin draws its bow and releases an arrow. It is an easy shot, and the arrow hits you square in the chest.");
                    }
                    gs.current = "lose";
                    Pause();
                    break;
                case 2:
                    if (HasItem(gs, "sword")) {
                        Console.WriteLine("You lay your sword on the floor and stand still");
                        gs.inventory.Remove("sword");
                    } else if (HasItem(gs, "bow")) {
                        Console.WriteLine("You lay your bow on the floor and stand still.");
                        gs.inventory.Remove("bow");
                    } else {
                        Console.WriteLine("You put your hands up, and stand still.");
                    }
                    Console.WriteLine("With their bows still pointing at you they slowly approach you, before they tie your hands behind your " +
                        "back.");
                    gs.current = "captured";
                    break;
            }
        }

        // Accessed from "dead horse"
        // Baern is nowhere to be found in sharnwick and must back to search for him
        // Regardless of player decisions, function accesses "dead horse"
        static void Sharnwick(GameState gs) {
            Console.WriteLine("After another few hours in the distance you spot the small town of Sharnwick. Theres a inn, shops and " +
                "a chapel. It isn't as big of a town as Chadford, so it doesn't take you long to visit all of the shops and houses. " +
                "After looking around the town, you realise that you can't find Baern. Perhaps he's somewhere back in Chadford.");
            Pause();
            Console.WriteLine("You decide, as there is nothing else to do, to turn back and head back to Chadford.");
            Pause();
            gs.current = "dead horse";
        }

        // Accessed from multiple functions
        // If the player chooses to drink the rum they die from poisoning
        static void Rum(GameState gs) {
            Console.WriteLine("The rum is an dark thick opaque looking liquid. You pop the cork off, and a noxious " +
                "smelling odour wafts from the opening of the bottle, you try your best not to gag. By now. from the " +
                "look and the smell, you are questioning yourself if it really is rum or the blacksmith is trying to poison you.");
            Pause();
            Console.WriteLine("You are having second thoughts about drinking the smith's 'rum'.");
            switch (PresentOptions(new List<string>() { "Yes", "No " }, "Are you really sure you want to drink the 'rum'.")) {
                case 0:
                    Console.WriteLine("Reluctantly, you take a sip of the smith's 'rum'. You start to feel dizzy and then a tingling " +
                        "sensation coming from all over your body. Your vision stating to blur, and before you know it you have passed out.");
                    gs.current = "Lose";
                    break;
                case 1:
                    Console.WriteLine("You decide to put the cork back on the bottle.");
                    gs.current = gs.last;
                    break;
            }
            Pause();
            Console.WriteLine();
        }

        // Accessed from "dead horse"
        // The main character has snuck into the goblin's hideout
        static void Hideout(GameState gs) {
            if (HasBeenTo(gs, "hideout") == false) {
                Console.WriteLine("You follow the goblins down the trail until you arrive at what seems to be their hideout. There are tents " +
                    "campfires and there is a cave. From your hiding spot, although the cave is lit dimly by torch light, you can see Baern, " +
                    "however he is trapped in a cell.");
                Pause();
                Console.WriteLine("As you sneak closer to the cell, you stop. You notice that there is a singular guard keeping watch over " +
                    "the cell. In its right hand it is holding a club and in its left hand it is holding the keys to the cell.");
            }
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Attack the guard",
                "Try to sneak past the guard to free Baern"
            };
            switch(PresentOptions(options, message)) {
                case 0:
                    if (HasItem(gs, "bow") && HasItem(gs, "arrow")) {
                        Console.WriteLine("You knock an arrow into your bow and aim it towards the goblin guard. " +
                            "You release the arrow and it hits the guard.");
                        Pause();
                        Console.WriteLine("Using the keys that the guard dropped when you hit it with the arrow, you unlock the cell and free Baern");
                        gs.current = "win";
                    } else {
                        if (HasItem(gs, "bow")) {
                            Console.WriteLine("You have a bow, but you are out of arrows.");
                        } else {
                            Console.WriteLine("You are unarmed");
                        }
                        switch (PresentOptions(new List<string>() { "Yes", "No" }, "Are you sure you want to do this?")) {
                            case 0:
                                Console.WriteLine("You try to sneak up behind the goblin guard, but it notices you. The goblin guard, hits you " +
                                    "with its club and knocks you out.");
                                Pause();
                                Console.WriteLine("You eventually wake up inside the cell, but your weapons have been taken off you.");
                                gs.current = "captured";
                                break;
                            case 1:
                                Console.WriteLine("You decide its best not to engage in a fight against the goblin guard without proper weapons.");
                                Pause();
                                break;
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("The goblin guard is looking a little drowsy. You decide to take this opportunity to try take the keys " +
                        "from it without it noticing. The goblin guard however, wakes up and hits you with its club, knocking you out.");
                    Console.WriteLine("You eventually wake up inside the cell that the guard was taking after.");
                    gs.current = "captured";
                    break;
            }
        }

        // Accessed from "ambushed"
        // The main character is captured by the goblin ambushers
        static void Captured(GameState gs) {
            if (gs.last == "ambushed") {
                Console.WriteLine("The goblins take you down a concealed path at the side of the road. The trail is a narrow path that winds through " +
                    "the thick forrests that surround the road.");
                Pause();
                Console.WriteLine("Eventually you arrive at a cave, which is dimly lit by torches mounted to the walls. " +
                    "They then take you to a prison cell in which they lock you inside. A goblin guard stands outside the cell, with a club in its " +
                    "right hand and the keys to the cell in its left.");
                Pause();
                Console.WriteLine("In the dim light of the cell, you recognise a familiar face, Baern. Baern tells you \"I was afraid this might" +
                    "happen, now you've been dragged into this mess\". ");
                Pause();
            }
            string message = "What do you do next?";
            List<string> options = new List<string>();
            if (HasItem(gs, "lockpicking kit") && HasItem(gs, "rum")) {
                Console.WriteLine("You realise that the goblins forgot to take away your lockpicking kit. And for some reason the goblins " +
                    "let you bring the bottle of rum to the cell. You sigh in relief, not all hope is lost.");
                options = new List<string>() { "Drink the 'rum'", "Offer the 'rum' to the guard", "Use the lockpicking kit on the cell" };
            } else if (HasItem(gs, "lockpicking kit")) {
                Console.WriteLine("You realise that the goblins forgot to take away your lockpicking kit, you sigh in relief, not all hope is lost.");
                Pause();
                gs.current = "escape";
            } else if (HasItem(gs, "rum")) {
                Console.WriteLine("You realise, for some reason the goblins hadn't taken away your rum. " +
                    "Despite your hopeless situation, you still " +
                    "have a few ideas about what you can do.");
                options = new List<string>() { "Drink the 'rum'", "Offer the 'rum' to the guard" };
            }
            if (options.Count > 0) {
                switch(PresentOptions(options, message)) {
                    case 0:
                        gs.current = "rum";
                        break;
                    case 1:
                        gs.current = "rum guard";
                        break;
                    case 2:
                        gs.current = "escape";
                        break;
                }
            } else if (gs.current != "escape") {
                Console.WriteLine("With no weapons or items to help you, you don't know what to do. You have run out of options.");
                gs.current = "lose";
            }
        }

        // Accessed from "captured"
        // The main character tries to break free from the cell using a lockpik but fails
        // Regardless of player decisions, function accesses "lose"
        static void Escape(GameState gs) {
            Console.WriteLine("You show the lockpicking kit to Baern, and his eyes light up. You quietly stand up to the cell lock, and try " +
                "your best to lockpick it.");
            Pause();
            Console.WriteLine("Despite not being proficient in using the lockpicking kit you manage to break the lock. You give a thumbs up " +
                "to Baern. As you push the cell door open, it makes a loud creeeek. ");
            Pause();
            Console.WriteLine("The goblin guard who had almost fallen asleep on post, wakes up, and hits you with its club, knocking you out.");
            Pause();
            Console.WriteLine("You wake up in your cell, but this time without your lockpicking kit.");
            gs.inventory.Remove("lockpicking kit");
            Pause();
            gs.current = "captured";
        }

        // Accessed from "captured"
        // The main character offers the rum to the goblin guard, causing the goblin guard to pass out and drop its keys
        // Regardless of player decisions, function accesses "win"
        static void RumGuard(GameState gs) {
            Console.WriteLine("You offer the smith's rum to the goblin guard. The goblin guard doesn't say anything, but picks up " +
                "the bottle and pops the cork. The guard doesn't seem to question why the rum is a dark thick liquid, or notice the " +
                "noxious smelling odour coming from it and takes a sip. ");
            Pause();
            Console.WriteLine("The goblin guard stands still for a moment, before he collapses to the ground. The keys are dropped by the " +
                "edge of the cell.");
            Pause();
            Console.WriteLine("Picking up the keys, you unlock the cell door. The guard, being passed out, doesn't do anything to stop the two " +
                "of you, so you and Baern are able to escape the goblins. ");
            Pause();
            gs.current = "win";
        }

        // Accessed when the player wins the game
        // Lets player know that they have won the game, gives the player option to play again or quit
        static void Win(GameState gs) {
            Console.WriteLine("You have won the game");
            string message = "What do you do next?";
            List<string> options = new List<string>() {
                "Return to menu",
                "Quit"
            };
            switch (PresentOptions(options, message)) {
                case 0:
                    gs.current = "menu";
                    gs = NewGame();
                    break;
                case 1:
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
                "Return to menu",
                "Quit"
            };
            switch (PresentOptions(options, message)) {
                case 0:
                    gs.current = "menu";
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

        // Promps the user to press any key to continue and reads a key
        // Use this to separate large blocks of text to prevent player from skim reading
        static void Pause() {
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey();
            Console.WriteLine();
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
            Pause();
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
        // This can be modified for testing purpouses as to start at a different point in the story
        static GameState NewGame() {
            GameState gs = new GameState();
            gs.current = "menu";
            gs.beenTo = new List<string>() { "menu" };
            gs.inventory = new List<string>();
            gs.gp = 10;
            gs.last = "menu";
            gs.spottedGoblins = false;
            return gs;
        }

        // Contains all information about the player and the environment
        // Use GameState rather than global varialbes
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
            // Shows whether the player has or hasn't seen the goblin ambushes on the trail between Chadwick and Sharnwick
            public bool spottedGoblins;
        }
    }
}