using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibs;
using MobLibs;

namespace DungeonMK2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Olympus Mons";
            Console.WriteLine("Welcome to Mars, Slayer");

            Weapon handGun = new Weapon("M1911", 2, 5, 2, false);
            Weapon shotGun = new Weapon("Shotgun", 4, 6, 2, true);
            Weapon sawedOff = new Weapon("Shotgun", 5, 6, 2, false);
            Weapon plasmaRifle = new Weapon("Plasma Rifle", 5, 8, 0, true);
            Weapon rocketLauncer = new Weapon("Rocket Launcher", 10, 20, 3, true);

            Player player = new Player("Howard Burn", 15, 15, 10, 5, rocketLauncer, Origin.CaliCrazies);
            Console.WriteLine(player + "\n");

            bool exit = false;

            do
            {

                Console.WriteLine(GetRoom());

                Demon d1 = new Demon("Imp", 10, 10, 3, 12, 1, 6, "A small, flying demon with a barbed tail", 55);
                Demon d2 = new Demon("Summoner", 15, 15, 5, 10, 2, 8, "Summons other demons", 0);
                CaveYeti c1 = new CaveYeti("White One", 15, 20, 1, 5, 4, 5, "Big furry Yeti", "roar");
                StalinsMustache s1 = new StalinsMustache("Big flying stache of Communism", 8, 10, 3, 4, 4, 5, "see name", "The stache hardens");
                Witch w1 = new Witch("Witch", 6, 8, 4, 6, 5, 6, "Hideous and vile", "A cry that could crack glass sears your ears");
                Breeki b1 = new Breeki("Breeki", 4, 5, 4, 5, 4, 5, "Sneaky, very Sneaky", "The Breeki became more Sneekie");

                Monster[] monsters =
                {
                    d1, d1, d1, d2, c1, s1, w1, b1
                };

                Monster monster = monsters[new Random().Next(monsters.Length)];
                Console.WriteLine("In this room you see a " + monster.Name + "! \n");

                bool reload = false;
                do
                {
                    Console.WriteLine("\nChoose an action:\n" +
                        "A)ttack \n" +
                        "R)un away \n" +
                        "P)layer Stats \n" +
                        "M)onster Stats \n" +
                        "E)xit");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.WriteLine("You killed the {0}!", monster.Name);
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                reload = true;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("RUN AWAY!");
                            int blockedIn = new Random().Next(1);
                            if (blockedIn == 1)
                            {
                                reload = true;
                            }
                            else
                            {
                                Console.WriteLine("You've been blocked by the monster");
                            }
                            Combat.DoAttack(monster, player);
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("You have chosen an option not available. Please try again");
                            break;
                    }

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have been slain by the {0}!",
                            monster.Name);
                        exit = true;
                    }

                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("GAME OVER");

        }//End Main()

        private static string GetRoom()
        {
            string[] room =
            {
                "A dozen statues stand or kneel in this room, and each one lacks a head and stands in a posture of action or defense. All are garbed for battle. It's difficult to tell for sure without their heads, but two appear to be dwarves, one might be an elf, six appear human, and the rest look like they might be orcs. \n",
                "Three low, oblong piles of rubble lie near the center of this small room. Each has a weapon jutting upright from one end -- a longsword, a spear, and a quarterstaff. The piles resemble cairns used to bury dead adventurers.",
                "In the center of this large room lies a 30-foot-wide round pit, its edges lined with rusting iron spikes. About 5 feet away from the pit's edge stand several stone semicircular benches. The scent of sweat and blood lingers, which makes the pit's resemblance to a fighting pit or gladiatorial arena even stronger. \n",
                "Huge rusted metal blades jut out of cracks in the walls, and rusting spikes project down from the ceiling almost to the floor. This room may have once been trapped heavily, but someone triggered them, apparently without getting killed. The traps were never reset and now seem rusted in place. \n",
                "You open the door, and the reek of garbage assaults your nose. Looking inside, you see a pile of refuse and offal that nearly reaches the ceiling. In the ceiling above it is a small hole that is roughly as wide as two human hands. No doubt some city dweller high above disposes of his rubbish without ever thinking about where it goes. \n"
            };

            return room[new Random().Next(room.Length)];
        }
    }
}
