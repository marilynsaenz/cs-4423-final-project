using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler singleton;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    public int score = 0;
    float timeLeft = 100;

    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "Time Left: " + (int)timeLeft;
        scoreText.text = "Score: " + (int)score;
        if (timeLeft <= 0)
        {
            GameManager.singleton.GameOver();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            CountScore();
        }
    }

    void CountScore()
    {
        score += (int) timeLeft * 10;
        scoreText.text = score.ToString();
    }
}

