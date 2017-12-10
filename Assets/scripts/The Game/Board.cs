using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject brick;
  //  public GameObject walls;

    List<GameObject> board = new List<GameObject>();
    int counter = 0;
    public float release = 0;

  //  public Snake snake = new Snake();


    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            PlaceBrick(-4.5f + i * 6, 135f); //top
            PlaceBrick(-10.5f, 135f - i * 6); //left 2/3
        }

        for (int i = 0; i < 9; i++)
        {
            PlaceBrick(91.5f, 135f - i * 6); //right 1/3
            PlaceBrick(-10.5f, 39 - i * 6); //left 3/3
        }

        for (int i = 0; i < 16; i++)
        {
            PlaceBrick(91.5f, 81f - i * 6); //right 1/3
            PlaceBrick(-4.5f + i * 6, -9f); //bottom
        }

        InvokeRepeating("ShowTheBoard", 0, .02f);
    }

    void PlaceBrick(float x, float y)
    {
        var newObject = Instantiate(brick, new Vector2(x, y), Quaternion.identity); 
        newObject.transform.parent = transform;
        newObject.transform.localScale = Vector3.zero;
        newObject.name = (counter.ToString());
        board.Add(newObject);
        counter++;
    }

    void ShowTheBoard()
    {
        for(int i = 0; i < board.Count; i++)
        {
            GameObject scalar = board[i];
            if (i < release)
            {
                Vector3 grow = Vector3.Lerp(scalar.transform.localScale, Vector3.one * 2, .1f);
                board[i].transform.localScale = grow;
            }
            release += Time.deltaTime;
        }

        if (release > 350)
        {
            CancelInvoke("ShowTheBoard");
        }
    }


}
