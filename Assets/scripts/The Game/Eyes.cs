using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour, IEyes
{
    public GameObject eyes;
    public GameObject bigEyes;
    public GameObject deadEyes;

    GameObject whichEyes;

    public GameObject head;
    public GameObject direction;

    public float activeBigEyes { get; set; }
    public bool activeDeadEyes { get; set; }


    void Start()
    {
        eyes.SetActive(false);
        bigEyes.SetActive(false);
        deadEyes.SetActive(false);

        whichEyes = eyes;

        StartCoroutine(setEyes());
    }

    IEnumerator setEyes()
    {
        yield return new WaitForSeconds(1.2f);
        whichEyes.SetActive(true);
    }

    void Update()
    {
        if (activeBigEyes < 0)
        {
            whichEyes = eyes;
            bigEyes.SetActive(false);
            eyes.SetActive(true);
        }
        else
        {
            whichEyes = bigEyes;
            eyes.SetActive(false);
            bigEyes.SetActive(true);
            activeBigEyes -= Time.deltaTime;
        }

        if (activeDeadEyes == true)
        {
            whichEyes = deadEyes;
            deadEyes.SetActive(true);
            eyes.SetActive(false);
            bigEyes.SetActive(false);
        }

        transform.position = head.transform.position + Vector3.forward;

        transform.rotation = Quaternion.Lerp(transform.rotation, direction.transform.rotation, .3f);
    }
}
