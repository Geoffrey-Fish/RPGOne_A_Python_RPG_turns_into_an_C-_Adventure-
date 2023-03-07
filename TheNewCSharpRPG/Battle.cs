namespace RPGOne
    {
    public class Battles
        {
        public static void Battle(Character attacker,Player defender)
            {
            Initiative(attacker,defender);

            void Initiative(Character att,Player def)
                {
                // INITIATIVE PHASE
                if(att.RollDice(0,100) + (att.dex / 5) >= def.RollDice(0,100) + (def.dex / 5))
                    {
                    Console.WriteLine($"{att.name} HAS INITIATIVE");
                    // ATTACKER ATTACK PHASE
                    FoeAttack(att,def);
                    }
                else
                    {
                    Console.WriteLine($"{def.name} HAS INITIATIVE");
                    // DEFENDER ATTACK PHASE
                    HeroAttack(def,att);
                    }
                }

            void FoeAttack(Character attacker,Player defender)
                {
                Console.WriteLine($"{attacker.name} IS ATTACKING {defender.name}");
                if(attacker.RollDice(0,100) >= defender.RollDice(0,100))
                    {
                    Console.WriteLine($"{attacker.name} HITS {defender.name}");
                    defender.hp -= (attacker.dmg - defender.ar);
                    Console.WriteLine($"{attacker.name} DOES {attacker.dmg} DAMAGE");
                    Console.WriteLine($"{defender.name} NOW HAS {defender.hp} HP");
                    }
                else
                    {
                    Console.WriteLine($"{attacker.name} misses {defender.name}.");
                    }
                }

            void HeroAttack(Player attacker,Character defender)
                {
                Console.WriteLine($"{attacker.name} IS ATTACKING {defender.name}");
                if(attacker.RollDice(0,100) >= defender.RollDice(0,100))
                    {
                    Console.WriteLine($"{attacker.name} HITS {defender.name}");
                    defender.hp -= (attacker.dmg - defender.ar);
                    Console.WriteLine($"{attacker.name} DOES {attacker.dmg} DAMAGE");
                    Console.WriteLine($"{defender.name} NOW HAS {defender.hp} HP");
                    }
                else
                    {
                    Console.WriteLine($"{attacker.name} misses {defender.name}.");
                    }
                }
            }
        }
    }

