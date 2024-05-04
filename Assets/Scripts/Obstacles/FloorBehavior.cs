using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Collectable"))
        {
            GameManager.Instance.LoseLife();
        }
    }
}
