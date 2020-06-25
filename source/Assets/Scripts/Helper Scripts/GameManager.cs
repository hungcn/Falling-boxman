using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GameOver()
    {
        RestartGame();
        EndGame();
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 1f);
    }

    void RestartAfterTime()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
    void EndGame()
    {
        Debug.Log("Quit game");
    }

}
