using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    [SerializeField] private int lives;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        print("Sua pontuação atual é de: " + score);
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        print("Sua pontuação atual é de: " + score);
    }

    public void LoseLife()
    {
        lives--;
        print($"Você tem {lives} vidas restantes");
    }
}
