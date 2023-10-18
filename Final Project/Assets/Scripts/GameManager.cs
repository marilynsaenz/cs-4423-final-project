using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    Vector3 lastCheckpoint;
    public int hearts = -1;
    public int lives = -1;
    public bool isGameOver = false;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        isGameOver = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayerRespawned()
    {
        Pet pet = FindObjectOfType<Pet>();
        if (pet != null)
        {
            Vector3 checkpointPosition = GetLastCheckpoint();
            pet.ResetPet(checkpointPosition);
        }
    }
}
