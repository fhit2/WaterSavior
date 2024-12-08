using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public static LevelTransition Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);

    }

    public void Map()
    {
        SceneManager.LoadScene(2);
        AudioManager.Instance.SceneMusic(2);
    }
    
    public void Prolog()
    {
        SceneManager.LoadScene(3);
        AudioManager.Instance.SceneMusic(3);
    }

    public void Epilog()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
        AudioManager.Instance.SceneMusic(4);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.SceneMusic(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
