using UnityEngine;

// Namespace
namespace Assets.Game.Code.TheoryPractice
{
    // class
    public class FantasyHero
    {
        // variables
        private string name;
        private int hp;
        public int damage;
        private float armor;
        private int num = 45;

        // properties
        public int Number1 { get; set; } = 15;
        public int Number2 { get; private set; } = 25;
        public int Number3 { get; } = 35;
        public int Number4 { 
            get { return num; }
            set { num = value; }
        }

        // constructor
        public FantasyHero(string name, int hp, int damage, float armor)
        {
            this.name = name;
            this.hp = hp;
            this.damage = damage;
            this.armor = armor;

            Number3 = 10;
        }
        
        // method
        public void TakeDamage(int damage)
        {
            float finalDamage = damage * (1f - armor);

            hp -= (int)finalDamage;
        }

        // method
        public void ShowInfo()
        {
            Debug.Log($"{name}. HP: {hp}. Damage: {damage}. Armor: {armor}");

            //Number2 = 1; // OK
            //Number3 = 1; // Error
        }
    }
}