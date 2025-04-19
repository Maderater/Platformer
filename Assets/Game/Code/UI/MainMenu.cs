using Assets.Game.Code.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject fadeCanvas;
        [Space]
        [SerializeField]
        private string gameScene;

        private FadeInOut fade;

        public void Play()
        {
            fade.FadeIn(() =>
            {
                SceneManager.LoadScene(gameScene);
            });
        }

        public void Credits()
        {
            print("Credits");
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void Awake()
        {
            GameObject g = Instantiate(fadeCanvas);
            fade = g.GetComponent<FadeInOut>();
        }
    }
}