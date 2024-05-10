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
        float inputMoveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        if(inputMoveX != 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.DecreaseScore(scoreToDecrease);
    }
}
