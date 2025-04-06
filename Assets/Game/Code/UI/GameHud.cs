using UnityEngine;
using TMPro;

namespace Assets.Game.Code.UI
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI statsText;

        private int? maxEnemys = 0;

        public void SetStatsText(int current, int? max)
        {
            if (max == null)
            {
                statsText.text = $"{current}/{maxEnemys}";
            }
            else
            {
                statsText.text = $"{current}/{max}";
                maxEnemys = max;
            }
        }
    }
}