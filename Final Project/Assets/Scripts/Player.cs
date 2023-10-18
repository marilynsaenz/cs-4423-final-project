using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float minY;
    bool hitCheckpoint = false;

    [SerializeField] int maxHearts = 2;
    [SerializeField] int currentHearts;
    [SerializeField] int maxLives = 5;
    [SerializeField] int currentLives;

    [SerializeField] Text heartsText;
    [SerializeField] Text livesText;

    Vector3 respawnPosition;
    public SceneTransition sceneTransition;

    [SerializeField] AudioClip collectCoin;
    [SerializeField] AudioClip collectHeart;
    [SerializeField] AudioClip enemyHit;

    void Start()
    {
        if (GameManager.singleton.lives > -1)
        {
            currentLives = GameManager.singleton.lives;
            GameManager.singleton.lives = -1;
        }
        else
        {
            currentLives = maxLives;
        }

        if (GameManager.singleton.hearts > -1)
        {
            currentHearts = GameManager.singleton.hearts;
            GameManager.singleton.hearts = -1;
        }
        else
        {
            currentHearts = 1;
        }
        respawnPosition = transform.position;

        UpdateHearts();
        UpdateLives();
    }

    void FixedUpdate()
    {
        if (transform.position.y < minY)
        {
            LoseLife();
            
            if (currentLives < 1)
            {
                return;
            }
            
            if (hitCheckpoint)
            {
                Respawn();
            }
            else
            {
                currentHearts = maxHearts;
                RestartLevel();
            }
        }
    }

    void RestartLevel()
    {
        GameManager.singleton.lives = currentLives;
        currentHearts = 1;
        UpdateHearts();
        GameManager.singleton.hearts = currentHearts;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Respawn()
    {
        if (hitCheckpoint)
        {
            transform.position = GameManager.singleton.GetLastCheckpoint();
        }
        else
        {
            transform.position = respawnPosition;
            hitCheckpoint = false;
        }
        currentHearts = 1;
        UpdateHearts();
        GameManager.singleton.PlayerRespawned();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            hitCheckpoint = true;
        }
        if (other.CompareTag("Finish"))
        {
            GameManager.singleton.hearts = currentHearts;
            SceneManager.LoadScene("MainMenu");
        }
        if (other.CompareTag("Coin") && gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<AudioSource>().clip = collectCoin;
            GetComponent<AudioSource>().Play();
            ScoreHandler.singleton.AddScore(10);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Heart") && gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<AudioSource>().clip = collectHeart;
            GetComponent<AudioSource>().Play();
            CollectHearts();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy") && other.isTrigger && this.GetComponent<Collider2D>().IsTouching(other))
        {
            GetComponent<AudioSource>().clip = enemyHit;
            GetComponent<AudioSource>().Play();
            TakeDamage(1);
        }
    }

    public void CollectHearts()
    {
        if (currentHearts < maxHearts)
        {
            currentHearts++;
            UpdateHearts();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        UpdateHearts();

        if (currentHearts < 1)
        {
            currentHearts = 0;
            LoseLife();
        }
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLives();

        if (currentLives < 1)
        {
            sceneTransition.SlideOut();
            SceneTransition();
            GameManager.singleton.GameOver();
        }
        else
        {
            currentHearts = 1;
            GameManager.singleton.hearts = currentHearts;
            if (hitCheckpoint)
            {
                Respawn();
            }
            else
            {
                RestartLevel();
            }
        }
    }
        
    void SceneTransition()
    {
        StartCoroutine(WaitForSlideThenGameOver());
        IEnumerator WaitForSlideThenGameOver()
        {
            yield return new WaitForSeconds(sceneTransition.GetSlideTime());
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateHearts()
    {
        heartsText.text = "Hearts: " + currentHearts;
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + currentLives;
    }
}