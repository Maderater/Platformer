using Assets.Game.Code.Effects;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
        private Image toggleTutorialBackground;
        [SerializeField]
        private TextMeshProUGUI toggleTutorialText;
        [SerializeField]
        private Sprite tutorialOn;
        [SerializeField]
        private Sprite tutorialOff;
        [Space]
        [SerializeField]
        private string gameScene;

        private FadeInOut fade;
        private Coroutine creditsCoroutine;

        public static bool ToggleTutorial = true;

        private void Awake()
        {
            GameObject g = Instantiate(fadeCanvas);
            fade = g.GetComponent<FadeInOut>();

            creditsCurtain.alpha = 0;
            creditsCurtain.blocksRaycasts = false;

            TutorialButtonUpdate();
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

        public void TutorialToggle()
        {
            ToggleTutorial = !ToggleTutorial;

            TutorialButtonUpdate();
        }

        private void TutorialButtonUpdate()
        {
            if (ToggleTutorial)
            {
                toggleTutorialBackground.sprite = tutorialOn;
                toggleTutorialText.text = "Tutorial ON";
            }
            else
            {
                toggleTutorialBackground.sprite = tutorialOff;
                toggleTutorialText.text = "Tutorial OFF";
            }
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