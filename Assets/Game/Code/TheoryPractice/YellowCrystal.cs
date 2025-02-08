using Assets.Game.Code.Character;
using UnityEngine;

namespace Assets.Game.Code.TheoryPractice
{
    
    public class YellowCrystal : MonoBehaviour
    {
        // Сделать желтый кристалл.
        // Дать ссылки в скрипте кристала на 4 точки в случайных местах на сцене (желательно ближе к самому кристаллу).
        // Сделать детектор соприкасаний с кристалом (триггер) с проверкой что его коснулся игрок.
        // Удалять кристалл после соприкосновения с игроком.
        // Спавнить в указанных 4 точках по красному кристаллу.

        [SerializeField]
        private Transform groundPoint1;

        [SerializeField]
        private Transform groundPoint2;

        [SerializeField]
        private Transform groundPoint3;

        [SerializeField]
        private Transform groundPoint4;

        [SerializeField]
        private GameObject redCrystal;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Instantiate(redCrystal, groundPoint1.position, Quaternion.identity);
                Instantiate(redCrystal, groundPoint2.position, Quaternion.identity);
                Instantiate(redCrystal, groundPoint3.position, Quaternion.identity);
                Instantiate(redCrystal, groundPoint4.position, Quaternion.identity);
                Destroy(gameObject);
            }

            
        }


    }
        

}