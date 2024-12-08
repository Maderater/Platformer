using UnityEngine;

namespace Assets.Game.Code.Character
{
    public class Player : MonoBehaviour
    {
        private CharacterController characterController;
        private Animator animator;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            float horizontal = Input.GetAxis("Horizontal"); // -1 to 1
            bool jump = Input.GetKeyDown("space");

            characterController.Move(horizontal, jump);
        }
    }
}