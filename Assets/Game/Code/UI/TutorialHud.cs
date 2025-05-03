using System.Collections;
using UnityEngine;
using TMPro;
using System;
using Assets.Game.Code.Character;

namespace Assets.Game.Code.UI
{
    public class TutorialHud : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI tutorialTextBox;

        private CanvasGroup canvasGroup;

        private Coroutine appearCoroutine, acceptCoroutine;

        public static TutorialHud Instance;

        private void Awake()
        {
            Init();

            Instance = this;
        }

        private void Init()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }

        public void AppearTutorial(string tutorialText)
        {
            if (appearCoroutine != null)
            {
                StopCoroutine(appearCoroutine);
            }

            tutorialTextBox.text = tutorialText;
            appearCoroutine = StartCoroutine(AppearTutorialCoroutine());
        }

        public void Accept()
        {
            if (acceptCoroutine != null)
            {
                StopCoroutine(acceptCoroutine);
            }

            Player.IsInTutorial = false;
            acceptCoroutine = StartCoroutine(AcceptCoroutine());
        }

        private IEnumerator AppearTutorialCoroutine()
        {
            canvasGroup.alpha = 0f;

            while (canvasGroup.alpha < 1)
            {
                yield return new WaitForSeconds(0.01f);

                canvasGroup.alpha += 0.04f;
            }

            canvasGroup.blocksRaycasts = true;
        }

        public IEnumerator AcceptCoroutine()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = false;

            while (canvasGroup.alpha > 0)
            {
                yield return new WaitForSeconds(0.01f);

                canvasGroup.alpha -= 0.04f;
            }
        }
    }
}