using static System.Console;

namespace RPGOne
    {
    public class Character
        {
        public bool friend { get; set; }
        public string name { get; set; }
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public int max_hp { get; set; }
        public int hp { get; set; }
        public int st { get; set; }
        public int dex { get; set; }
        public int gp { get; set; }
        public int xp { get; set; }
        public List<Item> items { get; set; }
        public List<Weapon> weapons { get; set; }
        public List<Armor> armors { get; set; }
        public int dmg { get; set; }
        public int ar { get; set; }
        public string dialog { get; set; }

        public Character(bool friend,string name,int pos_x,int pos_y,int hp,int st,int dex,int gp,int xp,List<Item> items,List<Weapon> weapons,List<Armor> armors,string dialog)
            {
            this.friend = friend;
            this.name = name;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.hp = hp;
            this.st = st;
            this.dex = dex;
            this.gp = gp;
            this.xp = xp;
            this.items = items;
            this.weapons = weapons;
            this.armors = armors;
            this.dmg = weapons[0].dmgValue;
            this.ar = armors[0].arValue;
            this.dialog = dialog;
            }

        public void Status()
            {
            WriteLine(this.name);
            WriteLine(this.name + " POS X: " + this.pos_x);
            WriteLine(this.name + " POS Y: " + this.pos_y);
            WriteLine("HP: " + this.hp);
            WriteLine("STR: " + this.st);
            WriteLine("DEX: " + this.dex);
            WriteLine("DMG: " + this.dmg);
            WriteLine("AR: " + this.ar);
            WriteLine("GP: " + this.gp);
            WriteLine("XP: " + this.xp);

            foreach(Item item in this.items)
                {
                WriteLine("ITEMS: ");
                WriteLine(item.name);
                }
            foreach(Weapon weapon in this.weapons)
                {
                WriteLine("WEAPONS: ");
                WriteLine(weapon.name);
                }
            foreach(Armor armor in this.armors)
                {
                WriteLine("ARMORS: ");
                WriteLine(armor.Name);
                }
            }

        public int RollDice(int min,int max)
            {
            int roll = new Random().Next(min,max);
            WriteLine(this.name + " ROLLS: " + roll);
            return roll;
            }

        public void Dialog()
            {
            WriteLine(this.dialog);
            }

        public void QueueFree(Room room)
            {
            WriteLine(this.name + " IS DEAD.");
            foreach(Item item in this.items)
                {
                this.items.Remove(item);
                room.items.Add(item);
                }
            foreach(Weapon weapon in this.weapons)
                {
                this.weapons.Remove(weapon);
                room.weapons.Add(weapon);
                }
            foreach(Armor armor in this.armors)
                {
                this.armors.Remove(armor);
                room.armors.Add(armor);
                }
            }
        //Foes
        //bool friend, string name,int pos_x,int pos_y,int max_hp,int st,int dex,int gp,int xp,List<Item> items,List<Weapon> weapons,List<Armor> armors,string dialog
        public static Character orc_peon = new Character(false,"ORC PEON",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DIE DIE DIE BART, DIE!!!");
        public static Character orc_peewee = new Character(false,"ORC PEEWEE",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DIEDABADUU!!!");
        public static Character orc_boner = new Character(false,"ORC BONER",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DER BART, DER!!!");
        public static Character orc_baba = new Character(false,"ORC BABA",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"LOREM IPSUM!!!");
        //Friends
        public static Character friendly_wizard = new Character(true,"FRIENDLY WIZARD",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.wizards_staff },new List<Armor> { Armor.cloth_robe },"HELLO ADVENTURER I AM A FRIENDLY WIZARD.I HAVE BROUGHT YOU TO THIS REALITY!");
        public static Character rat_man = new Character(true,"RAT MAN",1,2,5,10,20,2,5,new List<Item> { Item.poison },new List<Weapon> { Weapon.stick },new List<Armor> { Armor.towel },"RAT TITTIES,FRESH RAT TITTIES!!!");
        public static Character store_clerk = new Character(true,"STORE CLERK",1,0,2,3,4,5,5,new List<Item> { Item.gem,Item.minor_health },new List<Weapon> { Weapon.stick },new List<Armor> { Armor.towel },"Hi THERE, STRANGER");

        }
    }