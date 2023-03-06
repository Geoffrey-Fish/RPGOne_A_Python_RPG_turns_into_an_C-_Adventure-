using static System.Console;
namespace RPGOne
    {
    /// <summary>
    /// Item Class contains all items in the game except Weapons and Armor
    /// </summary>
    public class Item
        {
        public string name { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }
        /// <summary>
        /// Constructor for Items
        /// </summary>
        /// <param name="name">Item name, descriptive</param>
        /// <param name="gpValue">Goldpoints, the Currency in the game</param>
        /// <param name="weight">Oh the weight!</param>
        public Item(string name,int gpValue,double weight)
            {
            this.name = name;
            this.gpValue = gpValue;
            this.weight = weight;
            }
        /// <summary>
        /// Status of current Item
        /// </summary>
        public void Status()
            {
            WriteLine(name);
            WriteLine("GP VALUE: " + gpValue.ToString());
            WriteLine("WEIGHT: " + weight.ToString());
            }
        /// <summary>
        /// Invocation of Items
        /// </summary>
        public static Item gem = new Item("GEM",100,0.1);
        public static Item poison = new Item("POISON",40,1);
        public static Item minor_health = new Item("MINOR_HEALTH",150,1);
        }
    }
//// Example usage
//short_sword.Status();
//        wizards_staff.Status();
//        stick.Status();
//        leather_armor.Status();
//        cloth_robe.Status();
//        towel.Status();
//        gem.Status();
//        poison.Status();
//        minor_health.Status();

