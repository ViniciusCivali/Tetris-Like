using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    //It marks the start of the period of time passed
    private float startTimePeriod = 0;
    //One second
    private float timePeriodToFall = 1;
    public float fallSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
        CheckUserInput();
    }

    void CheckUserInput ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveAround();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
    }

    void CheckTime()
    {
 
        if ((Time.time - startTimePeriod) >= timePeriodToFall)
        {
            ConstantDownwardMove();
            startTimePeriod = Time.time;
        }
    }

    void ConstantDownwardMove()
    {
        transform.position += new Vector3(0, -fallSpeed, 0);

        if (!CheckIsValidPosition())
        {
            transform.position += new Vector3(0, fallSpeed, 0);
        }
    }

    void MoveRight()
    {

        transform.position += new Vector3(1, 0, 0);


        if (!CheckIsValidPosition())
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);

        if (!CheckIsValidPosition())
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    void MoveAround()
    {
        transform.Rotate(0, 0, 90);

        if (!CheckIsValidPosition())
        {
            transform.Rotate(0, 0, -90);
        }
    }

    void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);

        if (!CheckIsValidPosition())
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }

    bool CheckIsValidPosition()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<Game>().Round(mino.position);

            if (FindObjectOfType<Game>().CheckIsInsideGrid(pos) == false)
            {
                return false;
            }
        }
        return true;
    }

}
