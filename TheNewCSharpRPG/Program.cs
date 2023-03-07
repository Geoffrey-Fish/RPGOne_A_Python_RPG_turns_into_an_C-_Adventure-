using static System.Console;


namespace RPGOne
    {
    class Program
        {
        /// <summary>
        /// Where the magic happens
        /// </summary>
        /// <param name="args">AAAAARRRRGHHH</param>
        static void Main(string[] args)
            {
            WriteLine("Proof of Concept for a simple CLI Dungeon adventure.\n" +
                "Material gathered a year ago with Python.");

            WriteLine("This is RPG One. A solo Adventure.");
            WriteLine();
            WriteLine("Welcome, stranger.");
            //Main loop
            while(true)
                {
                Player player = new Player();
                Narrative.Welcome(player.name);
                Grid(player);
                }
            }


        /// <summary>
        /// Secret main loop, check position of player and reacts accordingly
        /// </summary>
        /// <param name="rooms">The Room the player walked in</param>
        /// <param name="player">Captain Obvious</param>
        public static void Grid(Player player)
            {
            // Find the room that the player is in
            Room currentRoom = null;
            foreach(Room room in rooms)
                {
                if(room.posX == player.posX && room.posY == player.posY)
                    {
                    currentRoom = room;
                    break;
                    }
                }
            if(currentRoom == null)
                {
                // The player is not in any room
                // Handle this error case appropriately
                }
            else
                {
                currentRoom.Status();
                foreach(var npc in currentRoom.npcs)
                    {
                    if(npc.friend == false)
                        {
                        Battles.Battle(npc,player);
                        /* Here was the battle function.
                         * Trying to put it in an extra class.
                         * If not working, rebuild here*/
                        if(npc.hp <= 0)
                            {
                            player.xp += npc.xp;
                            npc.QueueFree(currentRoom);
                            currentRoom.npcs.Remove(npc);
                            }
                        }
                    }
                }
            Options(currentRoom,player);
            }


        /// <summary>
        /// Options is an interactive tool for the player to navigate the game
        /// </summary>
        /// <param name="room">the current room and its position</param>
        /// <param name="player">The Player himself in all his glory</param>
        public static void Options(Room room,Player player)
            {
            WriteLine("MOVE:\n| (N)ORTH\n| (E)AST\n| (S)OUTH\n| (W)EST\n|");
            WriteLine(" (L)OOK AT ME!\n| SHOW (R)OOM!\n|(M)AP?\n| ");
            WriteLine("  (I)NVENTORY?\n| (Q)UIT GAME");

            string user_input = player.UserInput();

            if(user_input == "N")
                {
                player.posY += 1;
                Grid(player);
                }
            else if(user_input == "S")
                {
                player.posY -= 1;
                Grid(player);
                }
            else if(user_input == "W")
                {
                player.posX -= 1;
                Grid(player);
                }
            else if(user_input == "E")
                {
                player.posX += 1;
                Grid(player);
                }
            else if(user_input == "L")
                {
                WriteLine("LOOK AT YOU!");
                player.Status();
                WriteLine("---------------------------------------------------------");
                Options(room,player);
                }
            else if(user_input == "R")
                {
                room.Status();
                /*print(Room.status(room) maybe
                 a function in rooms for locating the player
                 and return the corresponding room?*/
                Options(room,player);
                }
            else if(user_input == "M")
                {
                Map.Plan();
                Options(room,player);
                }
            else if(user_input == "I")
                {
                player.Inventory(room,player);
                }
            else if(user_input == "Q")
                {
                GameOver();
                }
            else
                {
                WriteLine("DUDE, WRONG INPUT!!!");
                // maybe here after choose drop,pick up?
                WriteLine("---------------------------------------------------------");
                Options(room,player);
                }
            }


        /// <summary>
        /// Exit function
        /// </summary>
        public static void GameOver()
            {
            Environment.Exit(0);
            }


        //Todo: needs to be better hidden
        /// <summary>
        ///Invocation of the rooms we are in.
        ///</summary>
        public static Room start_room = new Room("START ROOM","THIS IS THE STARTING ROOM",0,0,new List<Character> { Character.friendly_wizard },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room foe_room = new Room("ORC FOE ROOM","THIS IS THE ORC FOE ROOM",0,1,new List<Character> { Character.orc_peon,Character.orc_peewee,Character.orc_boner },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room gem_room = new Room("GEM ROOM","THIS IS THE GEM ROOM",0,-1,new List<Character> { },new List<Item> { Item.gem,Item.gem,Item.gem },new List<Weapon> { },new List<Armor> { });
        public static Room orc_room = new Room("ORC ROOM","THIS IS AN ORC ROOM",0,2,new List<Character> { Character.orc_baba },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room rat_room = new Room("RAT ROOM","LOOK! THE RAT MAN!",1,0,new List<Character> { Character.rat_man },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room stor = new Room("STORE","BUY IT NOW!",1,1,new List<Character> { Character.store_clerk },new List<Item> { Item.gem,Item.gem,Item.poison },new List<Weapon> { Weapon.short_sword,Weapon.stick },new List<Armor> { Armor.leather_armor,Armor.cloth_robe,Armor.towel });

        //todo:how to get to the store?
        //shit name STOR because of problems otherwise, it calls store.status() wich leads to the store method...that brakes the game(From Python)
        // the store is a class for itself...

        //these are just blockers, to be reworked laterwith waypoint tips
        public static Room wallm1m1 = new Room("WALL","NO WAY,TURN AROUND",-1,-1,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall1m1 = new Room("WALL","NO WAY,TURN AROUND",1,-1,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm10 = new Room("WALL","NO WAY,TURN AROUND",-1,0,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm11 = new Room("WALL","NO WAY,TURN AROUND",-1,1,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm12 = new Room("WALL","NO WAY,TURN AROUND",-1,2,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall12 = new Room("WALL","NO WAY,TURN AROUND",1,2,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall03 = new Room("WALL","NO WAY,TURN AROUND",0,3,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall0m2 = new Room("WALL","NO WAY,TURN AROUND",0,-2,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });


        /// <summary>
        /// Main List of the rooms
        /// </summary>
        public static List<Room> rooms = new List<Room> { start_room,foe_room,gem_room,orc_room,rat_room,stor,wallm1m1,wall1m1,wallm10,wallm11,wallm12,wall12,wall03,wall0m2 };

        ///////////////
        ///End Tags///
        /////////////
        }
    }

// TODO: Make wall rooms for not going into the abyss
//maybe give possible directions in the rooms if looked at?
//give hints about a store
//need interaction and talk with npcs
//use of health potions
//maybe even a game break for drinking with an alert or so
//whilst in fight - better than dying, right ?
//exit method ?