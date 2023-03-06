namespace RPGOne
    {
    /// <summary>
    /// Class for the weapons in the game
    /// </summary>
    public class Weapon
        {
        public string name { get; set; }
        public int dmgValue { get; set; }
        public int arValue { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }
        /// <summary>
        /// Randomizer for new and different weapons on every game
        /// </summary>
        private static Random rand = new Random();

        public Weapon(string name,int dmgValue,int arValue,int gpValue,double weight)
            {
            this.name = name;
            this.dmgValue = dmgValue;
            this.arValue = arValue;
            this.gpValue = gpValue;
            this.weight = weight;
            }
        /// <summary>
        /// Status of current selected Weapon
        /// </summary>
        public void Status()
            {
            Console.WriteLine(name);
            Console.WriteLine("DMG VALUE: " + dmgValue.ToString());
            Console.WriteLine("AR VALUE: " + arValue.ToString());
            Console.WriteLine("GP VALUE: " + gpValue.ToString());
            Console.WriteLine("WEIGHT: " + weight.ToString());
            }

        /// <summary>
        /// Invocation of weapons
        /// </summary>
        public static Weapon short_sword = new Weapon("SHORT SWORD",rand.Next(1,7),0,50,3);
        public static Weapon wizards_staff = new Weapon("WIZARDS STAFF",rand.Next(1,41),0,400,4);
        public static Weapon stick = new Weapon("STICK",1,0,1,0.1);

        }
    }