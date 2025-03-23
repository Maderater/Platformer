using Assets.Game.Code.Character;
using Assets.Game.Code.UI;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private string tutrialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().IsInTutorial = true;
            collision.GetComponent<Assets.Game.Code.Character.CharacterController>().VelocityToZero();
            collision.GetComponent<Animator>().SetFloat("Movement", 0);

            TutorialHud.Instance.AppearTutorial(tutrialText);

            Destroy(gameObject);
        }
    }
}
