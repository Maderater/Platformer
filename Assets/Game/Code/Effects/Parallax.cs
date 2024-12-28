using UnityEngine;

namespace Assets.Game.Code.Effects
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float parallaxIntencity;

        private Camera cam;
        private float startPos;

        private void Start()
        {
            cam = Camera.main;

            startPos = transform.localPosition.x;
        }

        private void Update()
        {
            Scroll();
        }

        private void Scroll()
        {
            float currentCameraPos = cam.transform.position.x;
            float distance = currentCameraPos * (1 - parallaxIntencity);

            transform.localPosition = new Vector3(startPos + distance, transform.localPosition.y, transform.localPosition.z);
        }
    }
}