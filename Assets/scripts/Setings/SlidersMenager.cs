using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlidersMenager : MonoBehaviour {

    public Slider sliderROne, sliderGOne, sliderBOne;
    public Slider sliderRTwo, sliderGTwo, sliderBTwo;

    public Slider sliderLenght;
    public Text lenght;
    public Slider sliderSpeed;
    public Text speed;
  

    public Material one;
    public Material oneForText;
    public Material two;

    public Camera cam;

    Color partsCol;
    Color bacgroundCol;

    void Start ()
    {        
        Color getColorOne;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("ColorOne"), out getColorOne);

        Color getColorTwo;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("ColorTwo"), out getColorTwo);

        sliderROne.value = getColorOne.r;
        sliderGOne.value = getColorOne.g;
        sliderBOne.value = getColorOne.b;

        sliderRTwo.value = getColorTwo.r;
        sliderGTwo.value = getColorTwo.g;
        sliderBTwo.value = getColorTwo.b;

        sliderSpeed.value = PlayerPrefs.GetFloat("speedOfCrawling");
        sliderLenght.value = PlayerPrefs.GetInt("sneakLenght");

        lenght.text = ("leNGhT: " + (int)(sliderLenght.value)).ToString();
        speed.text = ("sPeed: " + (Mathf.Round(sliderSpeed.value * 100) / 100).ToString());
    }

    void Update ()
    {
        partsCol = new Color(sliderROne.value, sliderGOne.value, sliderBOne.value, 1);
        bacgroundCol = new Color(sliderRTwo.value, sliderGTwo.value, sliderBTwo.value, 1);

        one.color = partsCol;
        oneForText.color = partsCol;
        two.color = bacgroundCol;

        cam.backgroundColor = bacgroundCol;

        sliderLenght.onValueChanged.AddListener(delegate { lenght.text = ("leNGhT: " + (int)(sliderLenght.value)).ToString(); });
        sliderSpeed.onValueChanged.AddListener(delegate { speed.text = ("sPeed: " + (Mathf.Round(sliderSpeed.value * 100) / 100).ToString()); });
    }


    public void Save()
    {
        PlayerPrefs.SetString("ColorTwo", ("#" + ColorUtility.ToHtmlStringRGBA(two.color)));
        PlayerPrefs.SetString("ColorOne", ("#" + ColorUtility.ToHtmlStringRGBA(one.color)));
        PlayerPrefs.SetFloat("speedOfCrawling", sliderSpeed.value);
        PlayerPrefs.SetInt("sneakLenght", (int)sliderLenght.value);

        SceneManager.LoadScene(0);
    }
}
