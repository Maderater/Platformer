using Assets.Game.Code.Character;
using Assets.Game.Code.Effects;
using Assets.Game.Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Code.Infrastracture
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject fadeCanvas;
        [SerializeField]
        private NextLevel nextLevel;
        [SerializeField]
        private GameHud gameHud;
        [Space]
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private Transform playerPoint;
        [Space]
        [SerializeField]
        private GameObject followCamera;

        [Header("Game Stats")]
        [SerializeField]
        private int enemyToDefeat;

        private FadeInOut fade;
        private GameObject character;

        private void Awake()
        {
            GameObject g = Instantiate(fadeCanvas);
            fade = g.GetComponent<FadeInOut>();

            character = Instantiate(player, playerPoint.position, Quaternion.identity);
            character.GetComponent<Player>().Init(fade, gameHud);

            GameObject f = Instantiate(followCamera, playerPoint.position, Quaternion.identity);
            f.GetComponent<FollowCamera>().Init(character.transform);
        }

        private void Start()
        {
            nextLevel.Construct(character.GetComponent<Player>(), enemyToDefeat);
            gameHud.SetStatsText(0, enemyToDefeat);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                fade.FadeIn(() =>
                {
                    SceneManager.LoadScene("MainMenu");
                });
            }
        }
    }
}