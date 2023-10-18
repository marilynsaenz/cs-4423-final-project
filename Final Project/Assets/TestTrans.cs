using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTrans : MonoBehaviour
{
    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
