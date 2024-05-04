using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FallingCollectable : MonoBehaviour
{
    [SerializeField] private float fallingSpeed;

    private void Update()
    {
        transform.Translate(0, fallingSpeed * Time.deltaTime * -1, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
