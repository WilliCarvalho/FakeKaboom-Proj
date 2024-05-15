using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int scoreToDecrease;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.GetIsGameOver() == true)
        {
            return;
        }

        float inputMoveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        if (inputMoveX != 0)
        {
            //Está se movendo
            animator.SetBool("isMoving", true);
        }
        else
        {
            //Está parado
            animator.SetBool("isMoving", false);
        }
        transform.Translate(inputMoveX, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        bool isGameOver = GameManager.Instance.GetIsGameOver();
        if (collider.collider.CompareTag("Collectable") && isGameOver == false)
        {
            GameManager.Instance.DecreaseScore(scoreToDecrease);
        }
    }
}