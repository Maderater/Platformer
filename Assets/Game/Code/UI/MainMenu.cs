using UnityEngine;

namespace Assets.Game.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            print("Play");
        }

        public void Credits()
        {
            print("Credits");
        }

        public void Exit()
        {
            Application.Quit();
            print("Exit");
        }
    }
}