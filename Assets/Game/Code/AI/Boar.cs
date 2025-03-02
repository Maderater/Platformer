using Assets.Game.Code.Interfaces;
using UnityEngine;

namespace Assets.Game.Code.AI
{
    public class Boar : MonoBehaviour, IDieble
    {
        [SerializeField]
        private Transform[] points;
        [SerializeField]
        private float speed;

        private Transform currentTarget;
        private int currentTargetIndex = 0;

        private Animator animator;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        private Vector2 currentVelocity;
        private int direction = 1; // -1 or 1
        private bool isAlive = true;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            currentTarget = points[currentTargetIndex];

            CalculateDirection();

            foreach (var point in points)
            {
                point.parent = null;
            }
        }

        private void Update()
        {
            Movement();
            TargetDirection();
        }

        private void Movement()
        {
            if (!isAlive) return;

            Vector2 targetVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
            rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, 0.05f);

            if (direction < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction > 0)
            {
                spriteRenderer.flipX = false;
            }
            //spriteRenderer.flipX = direction < 0;

            animator.SetFloat("Velocity", Mathf.Abs(direction));
        }

        private void TargetDirection()
        {
            if (!isAlive) return;

            if (Vector2.Distance(rb.position, currentTarget.position) < 0.2f)
            {
                // Next target index
                currentTargetIndex += 1;
                if(currentTargetIndex == points.Length)
                {
                    currentTargetIndex = 0;
                }

                // Next target
                currentTarget = points[currentTargetIndex];

                // Calculate direction
                CalculateDirection();
            }
        }

        private void CalculateDirection()
        {
            if (!isAlive) return;

            if (currentTarget.position.x - transform.position.x < 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }

        public void Die()
        {
            if (!isAlive) return;

            isAlive = false;
            gameObject.layer = LayerMask.NameToLayer("EnemyDead");
            rb.linearVelocity = new Vector2(0, 0);
            animator.SetTrigger("Die");
        }
    }
}