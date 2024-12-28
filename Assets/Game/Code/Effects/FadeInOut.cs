using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.Effects
{
    public class FadeInOut : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup curtain;

        private void Awake()
        {
            FadeOut();
        }

        public void FadeIn(Action OnFadeIn)
        {
            StartCoroutine(FadeInCoroutine(OnFadeIn));
        }

        public void FadeOut()
        {
            StartCoroutine(FadeOffCoroutine());
        }

        private IEnumerator FadeInCoroutine(Action OnFadeIn)
        {
            curtain.alpha = 0;

            while (curtain.alpha < 1)
            {
                yield return new WaitForSeconds(0.01f);

                curtain.alpha += 0.02f;
            }

            OnFadeIn?.Invoke();
        }

        private IEnumerator FadeOffCoroutine()
        {
            curtain.alpha = 1;

            while (curtain.alpha > 0)
            {
                yield return new WaitForSeconds(0.01f);

                curtain.alpha -= 0.02f;
            }
        }
    }
}