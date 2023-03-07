using static System.Console;
namespace RPGOne
    {
    //todo: this file is pretty much WIP
    /// <summary>
    /// This shall be the place for story telling
    /// </summary>
    public class Narrative
        {
        static Random rand = new Random();

        /// <summary>
        /// First greeting in the game
        /// </summary>
        /// <param name="name">Playername</param>
        public static void Welcome(string name)
            {
            WriteLine("You wander around yaddayadda\n" +
                "Bla bla bla,what?");
            WriteLine($"now, {name}, what will you do?");
            }

        /// <summary>
        /// Random greetings from friendly npcs
        /// </summary>
        public static void RandomGreeting()
            {
            string[] greeting = new string[]
                {
                    "Woah, Gods greeting","Welcome","Salve","Wrmpfldrmoph","What you want?"
                    };
            WriteLine($"{greeting[rand.Next(0,greeting.Length)]},");
            }


        /// <summary>
        /// Random Enemy attack phrases
        /// </summary>
        public static void EnemyAttack()
            {
            string[] enemyAttack = new string[]
                {
                    "Ha", "HUAGH", "Taketh thith", "BEMBEMBEMBEM"
                    };
            WriteLine($"{enemyAttack[rand.Next(0,enemyAttack.Length)]}");
            }
        }
    }


