using Assets.Game.Code.Effects;
using Assets.Game.Code.Interfaces;
using Assets.Game.Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private GameHud gameHud;

        public bool IsInTutorial { get; set; }

        public FadeInOut Fade { get; private set; }
        public int DefeatEnemy { get; private set; }

        public void Init(FadeInOut fade, GameHud gameHud)
        {
            Fade = fade;
            this.gameHud = gameHud;
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
            print(horizontal);
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
                DefeatEnemy += 1;
                gameHud.SetStatsText(DefeatEnemy, null);

                collider.GetComponent<IDieble>().Die();
            }
        }

        public void Die()
        {
            if (IsInTutorial) return;

            isAlive = false;
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Die");
            characterController.VelocityToZero();
            Invoke("FirstScene", 3f);
        }

        private void FirstScene() => Fade.FadeIn(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}