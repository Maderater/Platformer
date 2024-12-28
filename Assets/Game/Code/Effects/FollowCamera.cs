using UnityEngine;

namespace Assets.Game.Code.Effects
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float smoothTime;

        private Vector3 offset = new Vector3(0, 0, -10);
        private Vector3 currentVelocity = Vector3.zero;

        private Transform target;

        public void Init(Transform target)
        {
            this.target = target;
        }

        private void LateUpdate()
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
    }
}