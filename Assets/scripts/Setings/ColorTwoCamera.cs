using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTwoCamera : MonoBehaviour
{
    public Camera cam;

    private void Awake()
    {
        Color getBacgroundColor;
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("ColorTwo"), out getBacgroundColor);

        cam.backgroundColor = getBacgroundColor;
    }
}
