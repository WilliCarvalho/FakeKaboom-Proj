using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    [SerializeField] private int scoreToAdd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            GameManager.Instance.IncreaseScore(scoreToAdd);
        }
        else if (collision.gameObject.CompareTag("Hearth"))
        {
            GameManager.Instance.IncreaseLifeByOne();
        }
    }
}
