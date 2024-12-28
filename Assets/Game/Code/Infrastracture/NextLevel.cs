using Assets.Game.Code.Character;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.Infrastracture
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField]
        private string nextLevel;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Player>().Fade.FadeIn(() =>
                {
                    SceneManager.LoadScene(nextLevel);
                });
            }
        }
    }
}