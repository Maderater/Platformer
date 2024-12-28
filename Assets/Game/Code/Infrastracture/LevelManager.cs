using Assets.Game.Code.Character;
using Assets.Game.Code.Effects;
using UnityEngine;

namespace Assets.Game.Code.Infrastracture
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject fadeCanvas;
        [Space]
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private Transform playerPoint;
        [Space]
        [SerializeField]
        private GameObject followCamera;

        private FadeInOut fade;

        private void Awake()
        {
            GameObject g = Instantiate(fadeCanvas);
            fade = g.GetComponent<FadeInOut>();

            GameObject p = Instantiate(player, playerPoint.position, Quaternion.identity);
            p.GetComponent<Player>().Init(fade);

            GameObject f = Instantiate(followCamera, playerPoint.position, Quaternion.identity);
            f.GetComponent<FollowCamera>().Init(p.transform);
        }
    }
}