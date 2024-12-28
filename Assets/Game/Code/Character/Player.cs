using Assets.Game.Code.Effects;
using UnityEngine;

namespace Assets.Game.Code.Character
{
    public class Player : MonoBehaviour
    {
        private CharacterController characterController;
        private Animator animator;

        public FadeInOut Fade { get; private set; }

        public void Init(FadeInOut fade)
        {
            Fade = fade;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Movement();
            Attack();
        }

        private void Movement()
        {
            float horizontal = Input.GetAxis("Horizontal"); // -1 to 1
            bool jump = Input.GetKeyDown("space");

            animator.SetFloat("Movement", Mathf.Abs(horizontal));

            characterController.Move(horizontal, jump);
        }

        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}