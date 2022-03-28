using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScr : MonoBehaviour
{
    [SerializeField] GameObject GameoverObj;
    [SerializeField] Transform BlocksObjs;
    [SerializeField] HighScoresObject highScoresObject;
    public void Gameover()
    {
        GameoverObj.SetActive(true);
        Time.timeScale = 0;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            float ClassicScore = FindObjectOfType<ScoreCounterScr>().Score;
            if (highScoresObject.dataForSaving.ClassicHS < ClassicScore)
            {
                highScoresObject.dataForSaving.ClassicHS = ClassicScore;
                GetComponent<SaveManagerScr>().Save();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            float HyperScore = FindObjectOfType<EnemyMechanic>().Score;
            if (highScoresObject.dataForSaving.HyperHS < HyperScore)
            {
                highScoresObject.dataForSaving.HyperHS = HyperScore;
                GetComponent<SaveManagerScr>().Save();
            }
        }
    }
    public void Retry()
    {
        StartCoroutine(Restart(1));
    }
    public void RetryHyperCasual()
    {
        StartCoroutine(Restart(2));
    }
    IEnumerator Restart(int Scene)
    {
        Time.timeScale = 1;
        foreach (Transform BlockParent in BlocksObjs)
        {
            Destroy(BlockParent.gameObject);
        }
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(Scene);

    }
}
