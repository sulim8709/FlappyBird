using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public Text scoreText;
    public Player player;


    public GameObject gameOverUi;

    int score = 0;

    private void Awake() {
        player.OnDie += GameOver;
        player.OnScore += UpScore;
    }

    private void GameOver()
    {
        gameOverUi.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void UpScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
