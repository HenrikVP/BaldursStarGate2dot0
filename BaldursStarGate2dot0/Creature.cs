﻿namespace BaldursStarGate2dot0
{
    internal abstract class Creature
    {
        //Field
        private int health;

        //Property. GET returns value of field, SET sets value of field from [value]
        public int Health { 
            get 
            { 
                return health;
            }
            set 
            {
                //if value set for Health property is higher than max,
                //then value is capped at max. THEN health is set.
                if (value > MaxHealth) value = MaxHealth;
                health = value;
            }
        }
        
        public int MaxHealth { get; set; }
        public int Armor { get; set; }
        public string Type { get; set; } = "Unknown";

        public void ReduceHealth(int damage)
        {
            Health -= damage;
        }

    }
}
