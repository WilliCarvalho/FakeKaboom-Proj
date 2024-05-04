using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    [SerializeField] private int scoreToAdd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.IncreaseScore(scoreToAdd);
    }
}
