using Assets.Game.Code.Effects;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject fadeCanvas;
        [SerializeField]
        private CanvasGroup creditsCurtain;
        [Space]
        [SerializeField]
        private string gameScene;

        private FadeInOut fade;
        private Coroutine creditsCoroutine;

        private void Awake()
        {
            GameObject g = Instantiate(fadeCanvas);
            fade = g.GetComponent<FadeInOut>();

            creditsCurtain.alpha = 0;
            creditsCurtain.blocksRaycasts = false;
        }

        public void Play()
        {
            fade.FadeIn(() =>
            {
                SceneManager.LoadScene(gameScene);
            });
        }

        public void Credits()
        {
            if (creditsCoroutine != null)
                StopCoroutine(creditsCoroutine);

            creditsCoroutine = StartCoroutine(CreditsShowCoroutine());
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void CreditsHide()
        {
            if (creditsCoroutine != null)
                StopCoroutine(creditsCoroutine);

            creditsCoroutine = StartCoroutine(CreditsHideCoroutine());
        }

        private IEnumerator CreditsShowCoroutine()
        {
            creditsCurtain.blocksRaycasts = true;

            while (creditsCurtain.alpha < 1)
            {
                yield return new WaitForSeconds(0.01f);
                creditsCurtain.alpha += 0.04f;
            }
        }

        private IEnumerator CreditsHideCoroutine()
        {
            creditsCurtain.blocksRaycasts = false;

            while (creditsCurtain.alpha > 0)
            {
                yield return new WaitForSeconds(0.01f);
                creditsCurtain.alpha -= 0.04f;
            }
        }
    }
}