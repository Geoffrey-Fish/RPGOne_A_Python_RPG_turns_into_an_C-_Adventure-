using static System.Console;
namespace RPGOne
    {
    public class Narrative
        {
        static Random rand = new Random();
        public static void Welcome(string name)
            {
            WriteLine("You wander around yaddayadda\n" +
                "Bla bla bla,what?");
            WriteLine($"now, {name}, what will you do?");
            }

        public static void RandomGreeting()
            {


            string[] greeting = new string[]
                {
                    "Woah, Gods greeting","Welcome","Salve","Wrmpfldrmoph","What you want?"
                    };
            WriteLine($"{greeting[rand.Next(0,greeting.Length)]},");

            }

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


