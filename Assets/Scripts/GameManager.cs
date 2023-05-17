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
    public Text bestText;
    public Text gameOverCountdown;
    public float countTimer = 5;
    private bool stopScore = true;
    private double score = 0;
    private double best;


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
        if (!stopScore) scoreText.text = "" + (score / 100);
        if (best > 0) bestText.text = "" + (best / 100);
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
        if (score > best)
        {
            best = score; // TODO: persist in a file
        }
    }


    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
}