using static System.Console;

namespace RPGOne
    {
    internal class Player
        {
        public string name = "PLAYER";
        public int pos_x = 0;
        public int pos_y = 0;
        public int? max_hp = null;
        public int hp = 9;
        public int xp = 0;
        public int gp = 0;
        public int? st = null;
        public int? dex = null;
        public List<Item> items = new List<Item>();
        public List<Weapon> weapons = new List<Weapon> { };
        public List<Armor> armors = new List<Armor> { };
        public int dmg;
        public int ar;

        public void Status()
            {
            WriteLine(name + "`S POS X: " + pos_x);
            WriteLine(name + "`S POS Y: " + pos_y);
            WriteLine("HP: " + hp);
            WriteLine("STR: " + st);
            WriteLine("DEX: " + dex);
            WriteLine("DMG: " + dmg);
            WriteLine("AR: " + ar);
            WriteLine("GP: " + gp);
            WriteLine("XP: " + xp);

            foreach(Item item in items)
                {
                WriteLine(item.Name);
                }

            foreach(Weapon weapon in weapons)
                {
                WriteLine(weapon.Name);
                }

            foreach(Armor armor in armors)
                {
                WriteLine(armor.Name);
                }
            }

        public string UserInput()
            {
            string? user_input = ReadLine().ToUpper().Trim();
            return user_input;
            }

        public void Create()
            {
            WriteLine("CREATING YOUR CHARACTER:");
            WriteLine("(N)AME YOUR CHARACTER");
            WriteLine("(R)OLL YOUR CHARACTER");
            WriteLine("(P)LAY GAME");
            Write("==> ");
            string user_input = UserInput();

            switch(user_input)
                {
                case "N":
                    WriteLine("WHAT IS YOUR NAME?");
                    user_input = UserInput();
                    name = user_input;
                    WriteLine($"{name}?\nSOUNDS ABOUT RIGHT.");
                    Thread.Sleep(1000);
                    Create();
                    break;
                case "R":
                    WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                    WriteLine("LET'S SEE YOUR HEALTH...");
                    WriteLine("ROLLING HP...");
                    Thread.Sleep(1000);
                    int roll = RollDice(name,20,40);
                    hp = roll;
                    WriteLine($"YOU HAVE NOW {hp} HP!");
                    Thread.Sleep(1000);
                    WriteLine("---------------------------------------------------------");
                    WriteLine("LET'S SEE YOUR MUSCLES THEN...");
                    WriteLine("ROLLING...");
                    Thread.Sleep(1000);
                    roll = RollDice(name,20,60);
                    st = roll;
                    WriteLine($"YOUR POWER IS {st} !");
                    Thread.Sleep(1000);
                    WriteLine("---------------------------------------------------------");
                    WriteLine("AT LAST YOUR DEXTERITY...");
                    WriteLine("ROLLING...");
                    Thread.Sleep(1000);
                    roll = RollDice(name,20,60);
                    dex = roll;
                    WriteLine($"{dex} IS YOUR DEXTERITY.");
                    WriteLine("---------------------------------------------------------");
                    Thread.Sleep(1000);
                    Create();
                    break;
                case "P":
                    if(name is "PLAYER" || hp is 0)
                        {
                        WriteLine("FINISH MAKING YOUR CHARACTER!");
                        WriteLine("---------------------------------------------------------");
                        Clear();
                        Create();
                        }
                    else
                        {
                        WriteLine("PLAY THE GAME!");
                        return;
                        }
                    break;
                default:
                    WriteLine("INVALID!\nCHOOSE AN OPTION:\n 'N', 'R' OR 'P'");
                    WriteLine("---------------------------------------------------------");
                    Create();
                    break;
                }
            }
        public static int RollDice(string name,int min,int max)
            {
            Random Dice = new Random();
            int roll = Dice.Next(min,max);
            WriteLine("{0} rolled a {1}",name,roll);
            return roll;
            }
        public void Inventory(Room room)
            {

            WriteLine("INVENTORY OPTIONS:\n| (P)ICK UP\n| (D)ROP\n| (B)ACK");
            string user_input = ReadLine().ToUpper();
            if(user_input == "P")
                {
                WriteLine("LOOK AT THE ITEMS HERE:");
                Thread.Sleep(1000);
                PickUp(room.items,this.items);
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
            void PickUp(List<Item> roomObjList,List<Item> playerObjList)
                {
                if(roomObjList.Count > 0)
                    {
                    foreach(Item obj in roomObjList)
                        {
                        WriteLine(obj.Name);
                        WriteLine("(P)ICK UP?\n| (N)EXT?\n| (B)ACK?");
                        string userInput = UserInput();
                        if(userInput == "P")
                            {
                            WriteLine(name + " PICKS UP " + obj.Name);
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
        }
    }