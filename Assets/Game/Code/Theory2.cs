using UnityEngine;

namespace Assets.Game.Code
{
    public class Theory2 : MonoBehaviour
    {
        // Пустые переменные (до тех пор пока не будут проинициализированы)
        private GameObject crystalGameObject;
        private Transform crystalTransform;
        private Rigidbody2D rb;
        private BoxCollider2D col;

        // Пустые переменные (до тех пор пока мы не дадим ссылку для них в инспекторе)
        public Rigidbody2D publicRb;
        [SerializeField]
        private Rigidbody2D sereilizedRb;

        private void Awake()
        {
            // Инициализация компонентов
            crystalGameObject = gameObject;
            crystalTransform = transform; // GetComponent<Transform>()
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            // Изменение позиции на старте
            crystalTransform.position = Vector3.zero;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Сравнение с тегом игрока для детекта ингрока вошедшего в триггер
            if (collision.CompareTag("Player"))
            {
                // Удаление компонентов
                Destroy(rb);
                Destroy(col);

                // Удаление объекта
                Destroy(crystalGameObject);
            }
        }
    }
}