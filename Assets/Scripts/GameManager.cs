using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Externals
    [SerializeField] private GameObject ballObject;
    private BallStart ballStart;
    [SerializeField] private Transform ballSpawnLocation;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button startGameButton;

    [HideInInspector] public int playerScore, enemyScore;
    [HideInInspector] public bool didPlayerHitBall = false;

    // Singletons
    public static GameManager instance;
    public float maxScore;

    // Internals

    private void Awake()
    {
        // Singleton Pattern
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        // Initializations
        ballStart = ballObject.GetComponent<BallStart>();
        maxScore = 5; // TODO: Add custom score limits
        gameOverText.gameObject.SetActive(false);
    }

    public void IncrementScore(bool isEnemy)
    {
        // Increment the player's score if they hit the enemy collider, vice versa.
        playerScore = isEnemy ? playerScore + 1 : playerScore;
        enemyScore = isEnemy ? enemyScore : enemyScore + 1;

        // Check for a winner
        if (playerScore >= maxScore || enemyScore >= maxScore)
        {
            gameOverText.text = isEnemy ? "You have won!" : "CPU has won!";
            gameOverText.gameObject.SetActive(true);
            startGameButton.gameObject.SetActive(true);
        }
        else
        {
            ResetBall();
        }
    }

    public void StartGame()
    {
        gameOverText.gameObject.SetActive(false);
        playerScore = 0;
        enemyScore = 0;
        ResetBall();
        startGameButton.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        ballObject.transform.position = ballSpawnLocation.position;
        ballStart.ResetBall();
    }
}
