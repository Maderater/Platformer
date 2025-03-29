using Assets.Game.Code.Character;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.Infrastracture
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField]
        private string nextLevel;

        private Player player;
        private int enemyToDefeat;

        public void Construct(Player player, int enemyToDefeat)
        {
            this.player = player;
            this.enemyToDefeat = enemyToDefeat;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && player.DefeatEnemy >= enemyToDefeat)
            {
                collision.GetComponent<Player>().Fade.FadeIn(() =>
                {
                    SceneManager.LoadScene(nextLevel);
                });
            }
        }
    }
}