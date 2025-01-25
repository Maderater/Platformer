using UnityEngine;

namespace Assets.Game.Code
{

    // MonoBehaviour — это базовый класс Unity, от которого наследуются пользовательские скрипты.
    // Этот класс предоставляет основные функциональные возможности для работы со сценой, объектами, событиями и игровым процессом.
    // MonoBehaviour находится в пространстве имен UnityEngine и является мостом между вашим C# кодом и игровым движком Unity.
    // Если скрипт не наследуется от MonoBehaviour, он не сможет быть привязан к объекту на сцене или использовать функции Unity.

    public class Theory : MonoBehaviour
    {
        private void Awake()
        {
            // Вызывается один раз, когда объект создается.
            // Используется для инициализации данных и зависимостей.
        }

        private void Start()
        {
            // Вызывается один раз перед первым кадром после инициализации.
            // Используется для начальной настройки объекта.
        }

        private void FixedUpdate()
        {
            // Вызывается через фиксированные интервалы времени. (по дефолту 50 раз в секунду)
            // Используется для работы с физикой (например, передвижение через Rigidbody).
        }

        private void Update()
        {
            // Вызывается каждый кадр. (fps = frame per second = кадры в секунду)
            // Используется для обновления логики (например, проверки ввода, движения).
        }

        private void OnDestroy()
        {
            // Вызывается, когда объект уничтожается.
        }

        private void TestMethod1(GameObject prefab)
        {
            print("");                      // MonoBehaviour    | Пишет сообщение в консоли движка
            Debug.Log("");                  // UnityEngine      | Пишет сообщение в консоли движка

            var c = StartCoroutine("");     // MonoBehaviour    | Запускает корутину (метод, работающий асинхронно).
            StopCoroutine(c);               // MonoBehaviour    | Останавливает указанную корутину.
            StopAllCoroutines();            // MonoBehaviour    | Останавливает все корутины объекта.

            GameObject g = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity); // MonoBehaviour    | Спавн объекта в указанной точке.
            Destroy(g);     // MonoBehaviour | Удаляет GameObject

            Theory testLifecycle = GetComponent<Theory>(); // MonoBehaviour |   Получение компонента из текущего GameObject

            GameObject go = gameObject; // GameObject к которому добавлен данный скрипт
            Transform t = transform; // Transform к которому добавлен данный скрипт
        }

        private void TestMethod2()
        {
            // Метод созданный нами

            // -----------------------------------------

            // Mathf                            | Математическая библиотека
            // Time.deltaTime                   | Время, прошедшее между кадрами. Используется для плавного движения.
            // Vector2/Vector3                  | Представляет вектор в 2D и 3D-пространстве (x, y, z).
            // Quaternion                       | Представляет вращение в Unity.
            // Raycast                          | Лучи, используемые для определения объектов на сцене.
            // Input                            | Обработка ввода пользователя.
            // Physics                          | Класс для работы с физикой.

            // gameObject.CompareTag("Player")  | Более эффективная альтернатива сравнению тегов.
        }
    }
}