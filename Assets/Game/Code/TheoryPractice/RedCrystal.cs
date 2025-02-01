using UnityEngine;

namespace Assets.Game.Code.TheoryPractice
{
    public class RedCrystal : MonoBehaviour
    {
        // Сделать красный кристал.
        // Сделать детектор соприкасаний с кристалом (триггер) с проверкой что его коснулся игрок.
        // Удалять кристал после соприкосновения с игроком.

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}