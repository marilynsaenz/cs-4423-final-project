using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -5f;
    public float minY = -5f;
    bool hitCheckpoint = false;

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);
        newPosition.x = Mathf.Max(newPosition.x, minX);
        transform.position = newPosition;

        if (transform.position.y < minY)
        {
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

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void Respawn()
    {
        Vector3 respawnPosition = GameManager.singleton.GetLastCheckpoint();
        transform.position = respawnPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            hitCheckpoint = true;
        }
    }
}
