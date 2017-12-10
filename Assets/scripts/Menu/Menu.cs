using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

    public Material one, oneForText, two;
    public Camera cam;

    void Start() 
    {
        if (PlayerPrefs.GetString("FirstStart") != "false")
        {
            PlayerPrefs.SetString("ColorOne", "#142b56ff");
            PlayerPrefs.SetString("ColorTwo", "#314d79ff");

            PlayerPrefs.SetFloat("speedOfCrawling", .4f);
            PlayerPrefs.SetInt("sneakLenght", 10);

            PlayerPrefs.SetString("FirstStart", "false");
        }

        Color getColourOne;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("ColorOne"), out getColourOne);

        Color getColourTwo;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("ColorTwo"), out getColourTwo);

        one.color = getColourOne;
        oneForText.color = getColourOne;
        two.color = getColourTwo;
        cam.backgroundColor = getColourTwo;
    }

    public void Play() 
    {
        SceneManager.LoadScene(2);
    }

    public void Setings()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
