using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject cactus;
    public bool end = false;
    public int score = 0, bestScore;
    public TextMeshProUGUI scoreText, gameOverScoreText, gameOverBestScoreText;
    public GameObject scorePanel;
    public GameObject readyImage01, readyImage02, gameOverImage, gameOverPanel;

    float randint;
    bool isStart = false;
    private void Awake()
    {
        manager = this;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

    }
    private void Update()
    { 
        randint -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Bird.bird.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
            iTween.FadeTo(readyImage01, iTween.Hash("alpha", 0, "time", 0.5f));
            iTween.FadeTo(readyImage02, iTween.Hash("alpha", 0, "time", 0.5f));
            scorePanel.SetActive(true);
            isStart = true;
        }

        if (randint <= 0 && isStart)
        {
            Instantiate(cactus);
            randint = Random.Range(2, 5);
            Debug.Log(randint);
        }

        if(score >= bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        UpdateScore();
    }
    public void GameOver()
    {
        end = true;
        randint = 9999999;
        iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 255, "delay", 0.1f, "time", 3f));
        StartCoroutine("GameOverPanel");
    }

    public void UpdateScore()
    {
        scoreText.text = "SCORE : " + score.ToString();
        gameOverScoreText.text = score.ToString();
        gameOverBestScoreText.text = bestScore.ToString();
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator GameOverPanel()
    {
        yield return new WaitForSeconds(3f);
        gameOverPanel.SetActive(true);
    }
}
