using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// Class for the Armors in the Game
    /// </summary>
    public class Armor
        {
        public string name { get; set; }
        public int arValue { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }
        /// <summary>
        /// Randomizer for new gear every game
        /// </summary>
        private static Random rand = new Random();
        /// <summary>
        /// Constructor for Armor
        /// </summary>
        /// <param name="name">Name of armor</param>
        /// <param name="arValue">Armor protection Value</param>
        /// <param name="gpValue">Goldpoints</param>
        /// <param name="weight">The weight!</param>
        public Armor(string name,int arValue,int gpValue,double weight)
            {
            this.name = name;
            this.arValue = arValue;
            this.gpValue = gpValue;
            this.weight = weight;
            }
        /// <summary>
        /// Status of the current Armor
        /// </summary>
        public void Status()
            {
            WriteLine(name);
            WriteLine("AR VALUE: " + arValue.ToString());
            WriteLine("GP VALUE: " + gpValue.ToString());
            WriteLine("WEIGHT: " + weight.ToString());
            }
        /// <summary>
        /// Invocation of the Armor
        /// </summary>
        public static Armor leather_armor = new Armor("LEATHER ARMOR",2,80,12);
        public static Armor cloth_robe = new Armor("CLOTH ROBE",1,5,2);
        public static Armor towel = new Armor("TOWEL",1,1,0.1);
        }

    }