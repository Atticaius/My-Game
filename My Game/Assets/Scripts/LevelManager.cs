using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public static LevelManager levelManager;
    public string currentScene;
    
    void Awake ()
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        } else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        if (autoLoadNextLevelAfter != 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel ()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadPreviousScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public string CurrentScene ()
    {
        return currentScene = SceneManager.GetActiveScene().name;
        
    }
}
