using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public Player player;
    public Text scoreText;
    private double score = 0;
    public Text gameOverCountdown;
    public float countTimer = 5;
    private bool stopScore = true;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCountdown.gameObject.SetActive(false);
        Time.timeScale = 0;
        score = 0;
    }

    private void Update()
    {
        if (player.isDead)
        {
            gameOverCountdown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
        }

        gameOverCountdown.text = "Restarting in " + (countTimer).ToString("0");

        if (countTimer < 0)
        {
            RestartGame();
        }

        score++;
        if (!stopScore) scoreText.text = "" + (score / 500);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
        stopScore = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        stopScore = true;
    }


    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
}