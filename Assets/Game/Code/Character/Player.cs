using Assets.Game.Code.AI;
using Assets.Game.Code.Effects;
using Assets.Game.Code.Interfaces;
using Assets.Game.Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

namespace Assets.Game.Code.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Transform hitPoint;
        [SerializeField]
        private LayerMask hittableLayer;

        private CharacterController characterController;
        private Animator animator;

        private bool isAlive = true;

        public bool IsInTutorial { get; set; }

        public FadeInOut Fade { get; private set; }

        public void Init(FadeInOut fade)
        {
            Fade = fade;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();

            TutorialHud.Instance.OnTutorialAccept += () =>
            {
                IsInTutorial = false;
            };
        }

        private void Update()
        {
            Movement();
            Attack();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (!isAlive) return;

                Die();
            }
        }

        private void Movement()
        {
            if (!isAlive || IsInTutorial) return;

            float horizontal = Input.GetAxis("Horizontal"); // -1 to 1
            bool jump = Input.GetKeyDown("space");

            animator.SetFloat("Movement", Mathf.Abs(horizontal));

            characterController.Move(horizontal, jump);
        }

        private void Attack()
        {
            if (!isAlive || IsInTutorial) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
            }
        }

        private void Hit()
        {
            if (!isAlive) return;

            Collider2D collider = Physics2D.OverlapCircle(hitPoint.position, 0.6f, hittableLayer);
            if (collider)
            {
                collider.GetComponent<IDieble>().Die();
            }
        }

        public void Die()
        {
            if (IsInTutorial) return;

            isAlive = false;
            animator.SetTrigger("Die");
            characterController.VelocityToZero();
            Invoke("FirstScene", 3f);
        }

        private void FirstScene() => Fade.FadeIn(() =>
        {
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
        });
    }
}