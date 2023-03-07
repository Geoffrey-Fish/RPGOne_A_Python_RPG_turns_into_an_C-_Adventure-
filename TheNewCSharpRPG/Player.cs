using static System.Console;

namespace RPGOne
    {/// <summary>
     /// It is more fun to be a Player, ayght? ^^
     /// </summary>
    public class Player
        {
        //todo: include weight and think about
        //todo: dmg and ar
        public string name = "PLAYER";
        public int posX = 0;
        public int posY = 0;
        public int? max_hp = null;
        public int hp = 0;
        public int xp = 0;
        public int gp = 0;
        public int? st = null;
        public int? dex = null;
        public List<Item> items = new List<Item>();
        public List<Weapon> weapons = new List<Weapon> { };
        public List<Armor> armors = new List<Armor> { };
        public int dmg; //by weapon
        public int ar; //armor


        /// <summary>
        /// Create Method is interactive
        /// </summary>
        /// <param name="Player">Empty object</param>
        public Player()
            {
            //Do while for creation. Only full rolled char may start
            bool creation = false;
            do
                {
                WriteLine("CREATING YOUR CHARACTER:");
                WriteLine("(N)AME YOUR CHARACTER");
                WriteLine("(R)OLL YOUR CHARACTER");
                WriteLine("(P)LAY GAME");
                Write("==> ");
                string? user_input = UserInput();

                switch(user_input)
                    {
                    case "N":
                        WriteLine("WHAT IS YOUR NAME?");
                        Write("=>>");
                        user_input = UserInput();
                        this.name = user_input;
                        WriteLine($"{name}?\n" +
                            $"SOUNDS ABOUT RIGHT.");
                        Thread.Sleep(1000);
                        break;

                    case "R":
                        WriteLine("---------------------");
                        WriteLine("LET'S SEE YOUR HEALTH...");
                        WriteLine("ROLLING HP...");
                        Thread.Sleep(1000);
                        int roll = RollDice(20,40);
                        hp = roll;
                        WriteLine($"YOU START WITH: {hp} HP!\n" +
                            $"SO YOUR HP CAP IS: {max_hp = hp * 4}");
                        Thread.Sleep(1000);

                        WriteLine("---------------------");
                        WriteLine("LET'S SEE YOUR MUSCLES THEN...");
                        WriteLine("ROLLING...");
                        Thread.Sleep(1000);
                        roll = RollDice(20,60);
                        st = roll;
                        WriteLine($"YOUR POWER IS {st} !");
                        Thread.Sleep(1000);

                        WriteLine("---------------------");
                        WriteLine("AT LAST YOUR DEXTERITY...");
                        WriteLine("ROLLING...");
                        Thread.Sleep(1000);
                        roll = RollDice(20,60);
                        dex = roll;
                        WriteLine($"{dex} IS YOUR DEXTERITY.");
                        WriteLine("---------------------");
                        break;

                    case "P":
                        if(name is "PLAYER" || hp is 0)
                            {
                            Clear();
                            WriteLine("FINISH MAKING YOUR CHARACTER!");
                            WriteLine("---------------------");
                            break;
                            }
                        else
                            {
                            //Everything is ok, lets go and end the do while loop
                            WriteLine("PLAY THE GAME!");
                            creation = true;
                            }
                        break;
                    default:
                        WriteLine("INVALID!\nCHOOSE AN OPTION:\n 'N', 'R' OR 'P'");
                        WriteLine("---------------------");
                        break;
                    }
                } while(!creation);
            }


        /// <summary>
        /// Takes Userinput, checks and converts it and returns the value
        /// </summary>
        /// <returns>Users choice</returns>
        public string UserInput()
            {
            // TODO: Here is a typecheck missing!
            string? user_input = ReadLine().ToUpper().Trim();
            return user_input;
            }


        //todo: include weight
        /// <summary>
        /// Show actual status of Player
        /// </summary>
        public void Status()
            {
            WriteLine(name + "`S POS X: " + posX);
            WriteLine(name + "`S POS Y: " + posY);
            WriteLine($"HP: {hp} OF: {max_hp}");
            WriteLine("STR: " + st);
            WriteLine("DEX: " + dex);
            WriteLine("DMG: " + dmg);
            WriteLine("AR: " + ar);
            WriteLine("GP: " + gp);
            WriteLine("XP: " + xp);
            WriteLine("---------------------");
            WriteLine("Your Bag contains: ");
            foreach(Item item in items)
                {
                WriteLine(item.name);
                }
            WriteLine("---------------------");
            WriteLine("Your Weapons: ");
            foreach(Weapon weapon in weapons)
                {
                WriteLine(weapon.name);
                }
            WriteLine("---------------------");
            WriteLine("Your Armor: ");
            foreach(Armor armor in armors)
                {
                WriteLine(armor.name);
                }
            }


        /// <summary>
        /// Personal Dice machine
        /// </summary>
        /// <param name="name">Playername</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value -1</param>
        /// <returns></returns>
        public int RollDice(int min,int max)
            {
            Random Dice = new Random();
            int roll = Dice.Next(min,max);
            WriteLine($"{name} rolled {roll}");
            return roll;
            }


        /// <summary>
        /// To look at the inventory whenever chosen
        /// </summary>
        /// <param name="room"> the room the player is at</param>
        public void Inventory(Room room)
            {
            WriteLine("INVENTORY OPTIONS:\n| (P)ICK UP\n| (D)ROP\n| (B)ACK");
            string user_input = ReadLine().ToUpper();
            if(user_input == "P")
                {
                WriteLine("LOOK AT THE ITEMS HERE:");
                Thread.Sleep(1000);
                PickUp(room.items,this.items);
                pickChangerItem(room.items,this.items);
                WriteLine("WHAT ABOUT THESE WEAPONS?");
                Thread.Sleep(1000);
                PickUp(room.weapons,this.weapons);
                WriteLine("SOME ARMOR, MAYBE?");
                Thread.Sleep(1000);
                PickUp(room.armors,this.armors);
                }
            else if(user_input == "D")
                {
                Drop(room);
                }
            else if(user_input == "B")
                {
                Console.WriteLine("GOING BACK TO MOVEMENT MENU");
                return;
                }
            }
        public static List pickChangerItem(List<T> room,List<T> player)
            {
            List<T> roomi = new List<T> { };
            List<T> playeri = new List<T> { };
            for(int j = 0;j < roomi.Length;j++)
                {
                roomi.Add(room[j]);
                }
            for(int i = 0;i < player.Length;i++)
                {
                playeri.Add(player[i]);
                }
            }





        //todo: Big Problem to be solved regarding different List types
        void PickUp(List<T> roomObjList,List<T> playerObjList)
            {
            if(roomObjList.Count > 0)
                {
                foreach(Item obj in roomObjList)
                    {
                    WriteLine(obj.name);
                    WriteLine("(P)ICK UP?\n| (N)EXT?\n| (B)ACK?");
                    string userInput = UserInput();
                    if(userInput == "P")
                        {
                        WriteLine(name + " PICKS UP " + obj.name);
                        roomObjList.Remove(obj);
                        playerObjList.Add(obj);
                        }
                    else if(userInput == "N")
                        {
                        continue;
                        }
                    else if(userInput == "B")
                        {
                        // pass or return or options call?
                        }
                    }
                }
            else
                {
                WriteLine("THERE IS NOTHING!WANNA DROP INSTEAD?\n| (Y)ES\n| (N)O");
                string userInput = UserInput();
                if(userInput == "Y")
                    {
                    Drop(room);
                    }
                else if(userInput == "N")
                    {
                    // pass
                    }
                }
            }

        void Drop(Room room)
            {
            if(items.Count == 0 && weapons.Count == 0 && armors.Count == 0)
                {
                WriteLine("OH BOY,HOW DID YOU GET NEKKID???CYA...");
                Grid(player);
                }
            WriteLine("DROP:\n| (I)TEM ? \n| (W)EAPON ?\n| (A)RMOR ?");
            string userInput = UserInput();
            if(userInput == "I")
                {
                WriteLine("DROPPING ITEM");
                foreach(Item item in items)
                    {
                    WriteLine("DROPPING " + item.Name);
                    WriteLine("You sure?\n| (Y)ES\n| OR (N)O");
                    string input = UserInput();
                    if(input == "Y")
                        {
                        items.Remove(item);
                        room.items.Add(item);
                        }
                    else if(input == "N")
                        {
                        continue;
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, DUDE.");
                        Drop(room);
                        }
                    }
                }
            else if(userInput == "W")
                {
                WriteLine("DROPPING WEAPON");
                foreach(Weapon weapon in weapons)
                    {
                    WriteLine("DROPPING " + weapon.Name);
                    WriteLine("You sure?\n| (Y)ES\n| OR (N)O");
                    string input = UserInput();
                    if(input == "Y")
                        {
                        weapons.Remove(weapon);
                        room.weapons.Add(weapon);
                        }
                    else if(input == "N")
                        {
                        continue;
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, DUDE.");
                        Drop(room);
                        }
                    }
                }
            else if(userInput == "A")
                {
                WriteLine("DROPPING ARMOR");
                foreach(Armor armor in armors)
                    {
                    WriteLine("DROPPING " + armor.Name);
                    WriteLine("You sure?\n| (Y)ES\n| OR (N)O");
                    string input = UserInput();
                    if(input == "Y")
                        {
                        armors.Remove(armor);
                        room.armors.Add(armor);
                        }
                    else if(input == "N")
                        {
                        continue;
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, COME ON!");
                        }
                    }
                }
            else
                {
                WriteLine("WRONG INPUT,GOOD LORD!!!");
                Drop(room);
                }
            }
        }

    internal class T
        {
        }
    }
