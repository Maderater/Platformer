using Assets.Game.Code.Interfaces;
using UnityEngine;

namespace Assets.Game.Code.AI
{
    public class Slime : MonoBehaviour, IDieble
    {
        private Animator animator;

        private bool isAlive = true;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Die()
        {
            if (!isAlive) return;

            isAlive = false;
            gameObject.layer = LayerMask.NameToLayer("EnemyDead");
            animator.SetTrigger("Die");
        }
    }
}