using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Text bestScore;
    public Text lastScore;

    int lastScoreValue, lastScoreView = 0;
    int scoreDelay;

    void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        lastScoreValue = PlayerPrefs.GetInt("LastScore");
    }

    void Update()
    {
        if (lastScoreView - 1 < lastScoreValue)
        {
            if (scoreDelay < 0)
            {
                lastScore.text = lastScoreView.ToString();
                float a = lastScoreView, b = lastScoreValue, c, d;
                c = Mathf.Pow(a, 16) / Mathf.Pow(b, 16) * 30;
                d = (b - a) / 16;
                lastScoreView++;
                lastScoreView += (int)d;
                scoreDelay = (int)c + 1;
            }
            else scoreDelay--;
        }
    }

    public void Replay() /// button method
    {
        SceneManager.LoadScene(2);
    }

    public void Quit() /// button method
    {
        SceneManager.LoadScene(0);
    }
}
