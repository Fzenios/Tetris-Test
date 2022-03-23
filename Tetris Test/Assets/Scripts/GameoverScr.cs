using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScr : MonoBehaviour
{
    [SerializeField] GameObject GameoverObj;
    public void Gameover()
    {
        GameoverObj.SetActive(true);
        Time.timeScale = 0;
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
