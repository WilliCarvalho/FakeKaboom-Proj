using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int scoreToDecrease;

    private void Update()
    {
        float inputMoveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        transform.Translate(inputMoveX, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.DecreaseScore(scoreToDecrease);
    }
}
