using UnityEngine;

namespace Assets.Game.Code.UI
{
    public class TutorialHud : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AppearTutorial();
            }
        }

        private void Init()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            Accept();
        }

        private void AppearTutorial()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }

        public void Accept()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
    }
}