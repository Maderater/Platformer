using Assets.Game.Code.Interfaces;
using UnityEngine;

namespace Assets.Game.Code.AI
{
    public class Bee : MonoBehaviour, IDieble
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform[] points;

        private Rigidbody2D rb;
        private Animator animator;

        private Transform currentTarget;
        private int currentTargetIndex = 0;
        private Vector2 direction;
        private bool isAlive = true;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            currentTarget = points[currentTargetIndex];

            foreach (var point in points)
            {
                point.parent = null;
            }

            WatchDirection();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            if (!isAlive)
            {
                return;
            }

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
                WatchDirection();
            }
        }

        private void WatchDirection()
        {
            direction = (Vector2)currentTarget.position - rb.position;
            transform.localScale = new Vector3((direction.x < 0) ? -1 : 1, 1, 1);
        }

        public void Die()
        {
            isAlive = false;
            gameObject.layer = LayerMask.NameToLayer("EnemyDead");
            animator.SetTrigger("Die");

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}