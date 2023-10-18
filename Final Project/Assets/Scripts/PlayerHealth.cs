using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField] int maxHearts = 2;
    // [SerializeField] int currentHearts;
    // [SerializeField] int maxLives = 5;
    // [SerializeField] int currentLives;
    // bool hasDied;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     currentHearts = maxHearts;
    //     currentLives = maxLives;
    //     hasDied = false;
    // }

    // void Update()
    // {
    //     if (transform.position.y < -7)
    //     {
    //         if (hitCheckpoint)
    //         {
    //             Respawn();
    //         }
    //         else
    //         {
    //             RestartLevel();
    //         }
    //     }
    // }

    // void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    // void Respawn()
    // {
    //     Vector3 respawnPosition = GameManager.singleton.GetLastCheckpoint();
    //     transform.position = respawnPosition;
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Checkpoint"))
    //     {
    //         hitCheckpoint = true;
    //     }
    // }

    // public void TakeDamage(int damage)
    // {
    //     currentHearts -= damage;

    //     if (currentHearts <= 0)
    //     {
    //         currentHearts = 0;
    //         PlayerDeath();
    //     }
    // }

    // void PlayerDeath()
    // {
    //     currentLives--;
    //     if(currentLives <= 0)
    //     {
    //         GameOver();
    //     }
    //     else
    //     {
    //         OnPlayerDeath?.Invoke();
    //     }
    // }

    // void GameOver()
    // {
    //     // Handle game over logic here. This might be showing a game over screen, and then taking the player back to the main menu.
    // }
}
