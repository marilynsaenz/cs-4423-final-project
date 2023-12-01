using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHandler : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
