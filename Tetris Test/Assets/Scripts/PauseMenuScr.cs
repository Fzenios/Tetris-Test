using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScr : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuObj;
    bool IsPaused;
    void Start()
    {
        IsPaused = false;
    }

    public void PauseGame()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            Time.timeScale = 0;
            PauseMenuObj.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenuObj.SetActive(false);
        }
    }
    public void ExitBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
