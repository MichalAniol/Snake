using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSnake : MonoBehaviour
{
    public GameObject deadEyes;
    public Text gameOver, gameOver2;

    private void Update()
    {
        if (deadEyes.GetComponent<IEyes>().activeDeadEyes == true)
        {
            gameOver.text = "gAMe\nOVeR";
            gameOver2.text = "gAMe\nOVeR";
        }
    }
}
