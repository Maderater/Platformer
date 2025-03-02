using UnityEngine;

namespace Assets.Game.Code.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private Transform groundPoint;
        [SerializeField]
        private LayerMask whatIsGround;
        [Space]
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private float jumpForce;

        private Rigidbody2D rb;

        private bool isGrounded;
        private Vector3 currentVelocity = Vector3.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            isGrounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoint.position, 0.1f, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                }
            }
        }

        public void Move(float move, bool jump)
        {
            Vector3 targetVelocity = new Vector2(move * movementSpeed, rb.linearVelocityY);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, 0.05f);

            if (isGrounded && jump)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0, jumpForce));
            }

            if(move < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if (move > 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }

        public void VelocityToZero() => rb.linearVelocity = Vector2.zero;
    }
}