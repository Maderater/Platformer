using UnityEngine;
using TMPro;

namespace Assets.Game.Code.UI
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI statsText;

        public void SetStatsText(string text)
        {
            statsText.text = text;
        }
    }
}