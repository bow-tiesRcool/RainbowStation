using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pauseModule;
    public bool isPaused;

    public static PauseManager pause;

    private void Awake()
    {
        if (pause == null)
        {
            pause = this;
            isPaused = false;
        }
    }

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isPaused)
        {
            pauseModule.SetActive(true);
        }
        if (!isPaused)
            pauseModule.SetActive(false);
    }

    public bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    public void LoadScene(string _level)
    {
        SceneManager.LoadScene(_level);
        isPaused = false;
    }
}
