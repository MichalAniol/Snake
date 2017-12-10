using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{
    public GameObject head;
    public GameObject eyes;
    public GameObject headDirection;


    void Update ()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                transform.position = mRay.GetPoint(1);

                Vector3 headDir = headDirection.transform.position - head.transform.position;
                Vector3 touchDir = transform.position - head.transform.position;

                float directionAngle = Vector3.Angle(headDir, touchDir);
                float directionSide = (Quaternion.Euler(0, 0, -head.transform.eulerAngles.z) * touchDir).x;

                if (directionAngle < 45)
                {
                    transform.rotation = head.transform.rotation;
                }
                else
                {
                    if (directionSide > 0) transform.rotation = Quaternion.Euler(0, 0, head.transform.eulerAngles.z - 90);
                    if (directionSide < 0) transform.rotation = Quaternion.Euler(0, 0, head.transform.eulerAngles.z + 90);
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) && Mathf.DeltaAngle(head.transform.rotation.eulerAngles.z, -90) < 180 - Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Mathf.DeltaAngle(head.transform.rotation.eulerAngles.z, 90) < 180 - Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.DeltaAngle(head.transform.rotation.eulerAngles.z, 0) < 180 - Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Mathf.DeltaAngle(head.transform.rotation.eulerAngles.z, 180) < 180 - Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
