using UnityEngine;

namespace Assets.Game.Code.AI
{
    public class Bee : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform[] points;

        private Rigidbody2D rb;

        private Transform currentTarget;
        private int currentTargetIndex = 0;
        private Vector2 direction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            currentTarget = points[currentTargetIndex];

            foreach (var point in points)
            {
                point.parent = null;
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, currentTarget.position, speed * Time.fixedDeltaTime);

            rb.MovePosition(newPosition);

            if (Vector2.Distance(rb.position, currentTarget.position) < 0.1f)
            {
                // Next target index
                currentTargetIndex += 1;
                if (currentTargetIndex == points.Length)
                {
                    currentTargetIndex = 0;
                }

                // Next target
                currentTarget = points[currentTargetIndex];

                //Watch direction
                direction = (Vector2)points[currentTargetIndex].position - rb.position;
                transform.localScale = new Vector3((direction.x < 0) ? -1 : 1, 1, 1);
            }
        }
    }
}