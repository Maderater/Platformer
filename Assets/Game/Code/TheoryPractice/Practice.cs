using UnityEngine;

namespace Assets.Game.Code.TheoryPractice
{
    public class Practice : MonoBehaviour
    {
        private FantasyHero worrior;
        private FantasyHero warden;
        private FantasyHero nekromant;

        private void Awake()
        {
            worrior = new FantasyHero("Worrior", 100, 40, 0.3f);
            warden = new FantasyHero("Warden", 80, 20, 0.1f);
            nekromant = new FantasyHero("Nekromant", 150, 10, 0.5f);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                worrior.ShowInfo();
                warden.ShowInfo();
                nekromant.ShowInfo();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                print("Fight!");

                warden.TakeDamage(worrior.damage);
                nekromant.TakeDamage(warden.damage);
                worrior.TakeDamage(nekromant.damage);
            }
        }
    }
}