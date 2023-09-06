﻿namespace BaldursStarGate2dot0
{
    internal class Game
    {
        //TODO Cleanup (refactoring)
        //TODO Choose weapons
        private Random rnd = new Random();

        public Game()
        {
            Console.WriteLine("We have started our game constructor by instantiating an object");
            Player pg = CreatePlayer();
            Monster mg = CreateMonster();
            Battle(pg, mg);
        }

        private void Battle(Player player, Monster monster)
        {
            while (true)
            {
                int att = 0;
                Console.WriteLine("Player opens a chest, and out jumps a... " + monster.Type);
                if (WhoStarts() == 0)
                {
                    att = Attack(monster);
                    att = Attack(player);
                }
                else
                {
                    //MonsterAttack(); 
                }
            }
        }

        private int Attack(Creature creature)
        {
            int att = AttackRoll();
            Console.WriteLine("Player swings, and rolls a " + att);
            att = ArmorReduction(att, creature);
            Console.WriteLine(creature.Type + "'s armor reduces attack to " + att);
            creature.ReduceHealth(att);
            Console.WriteLine($"{creature.Type} have {creature.Health} health left.");
            if (creature.Health <= 0) Console.WriteLine(creature.Type + " have died");
            return att;
        }

        private int ArmorReduction(int att, Creature creature)
        {
            return Math.Max(0, att - creature.Armor);
        }

        //TODO Add modifier dependent on weapon or creature 
        private int AttackRoll()
        {
            int att = rnd.Next(10);
            return att;
        }

        private int WhoStarts()
        {
            return rnd.Next(2);
        }

        private Player CreatePlayer()
        {
            Player pcp = new Player();
            pcp.MaxHealth = 100;
            pcp.Health = pcp.MaxHealth;
            pcp.Armor = 2;
            return pcp;
        }

        private Monster CreateMonster()
        {
            return new Monster();
        }

    }
}
