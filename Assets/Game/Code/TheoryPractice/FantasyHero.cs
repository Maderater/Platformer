using UnityEngine;

// ???????????? ????
namespace Assets.Game.Code.TheoryPractice
{
    // ?????
    public class FantasyHero
    {
        // ??????????
        private string name;
        private int hp;
        public int damage;
        private float armor;
        
        // ???????????
        public FantasyHero(string name, int hp, int damage, float armor)
        {
            this.name = name;
            this.hp = hp;
            this.damage = damage;
            this.armor = armor;
        }
        
        // ?????
        public void TakeDamage(int damage)
        {
            float finalDamage = damage * (1f - armor);

            hp -= (int)finalDamage;
        }

        // ?????
        public void ShowInfo()
        {
            Debug.Log($"{name}. HP: {hp}. Damage: {damage}. Armor: {armor}");
        }
    }
}