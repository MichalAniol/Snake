using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text bestScore;
    public Text lastScore;

	void Start ()
    {
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        lastScore.text = PlayerPrefs.GetInt("LastScore").ToString();
	}
}
