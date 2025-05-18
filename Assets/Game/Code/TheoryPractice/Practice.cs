using UnityEngine;

namespace Assets.Game.Code.TheoryPractice
{
    public class Practice : MonoBehaviour
    {
        private FantasyHero worrior;
        private FantasyHero warden;
        private FantasyHero nekromant;

        private float hp = 10.512842411221415521312414212f;
        private decimal money = 10.512842411221415521312414212m;

        //private int parseResult = 10;

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

            if (Input.GetKeyDown(KeyCode.G))
            {
                bool result = int.TryParse("350a", out int parseResult);
                print("result: " + result);

                //int parseResult = int.Parse("350a");
                //print(parseResult);

                //string text = "Mark25";
                //print(text);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                print("F: " + hp);
                print("D: " + money);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Number1: " + worrior.Number1); // 15
                print("Number2: " + worrior.Number2); // 25
                print("Number3: " + worrior.Number3); // 10
                print("Number4: " + worrior.Number4); // 45

                worrior.Number1 = 1;
                //worrior.Number2 = 1; // Error
                //worrior.Number3 = 1; // Error
                worrior.Number4 = 1;

                print("Number1: " + worrior.Number1); // 1
                print("Number2: " + worrior.Number2); // 25
                print("Number3: " + worrior.Number3); // 10
                print("Number4: " + worrior.Number4); // 1
            }
        }
    }
}