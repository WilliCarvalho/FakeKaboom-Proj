using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private FallingSpawner spawner;

    [Header("Game loop variables")]
    [SerializeField] private int lives;
    [SerializeField] private int increaseLifeByScoreRate = 500;
    private int targetScore;
    public int score;
    private bool isGameOver;

    [Header("Text variables")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    [Header("GameOverPanel variables")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        Instance = this;

        targetScore = increaseLifeByScoreRate;

        isGameOver = false;
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(Restart);
        UpdateLivesText(lives);
    }

    public void IncreaseLifeByOne()
    {
        lives++;
        UpdateLivesText(lives);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText(score);
        CheckScore();
    }

    private void CheckScore()
    {
        if(score >= 1000)
        {
            spawner.ChangeSpawnRate(1);
        }
        
        if(score >= targetScore)
        {
            lives++;
            UpdateLivesText(lives);
            targetScore += increaseLifeByScoreRate;
        }
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreText(score);
        print("Sua pontuação atual é de: " + score);
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText(lives);
        
        if(lives <= 0)
        {
            HandleGameOver();            
        }
    }

    private void HandleGameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        totalScoreText.text = $"Total Score: {score}";
        FallingCollectable[] collectablesLeft = FindObjectsOfType<FallingCollectable>();

        foreach(FallingCollectable collectableLeft in collectablesLeft)
        {
            Destroy(collectableLeft.gameObject);
        }
    }

    private void UpdateScoreText(int amount)
    {
        scoreText.text = amount.ToString();
    }

    private void UpdateLivesText(int amount)
    {
        livesText.text = $"Lives: {amount}";
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public int GetScore() 
    {
        return score; 
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }    
}
