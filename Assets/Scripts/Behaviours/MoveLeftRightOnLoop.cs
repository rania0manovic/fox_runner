using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRightOnLoop : MonoBehaviour
{
    bool positive;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        positive = true;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var currentPositionX = transform.position.x;
        if (counter == 70)
        {
            positive = false;
        }
        else if (counter == -70)
        {
            positive = true;
        }
        if (positive)
        {
            transform.position += new Vector3(currentPositionX * Time.deltaTime * 0.07f, 0, 0);
            counter++;
        }
        else
        {
            transform.position -= new Vector3(currentPositionX * Time.deltaTime * 0.07f, 0, 0);
            counter--;
        }
    }

    private IEnumerator WaitNSeconds(int n)
    {
        yield return new WaitForSeconds(n);
    }
}
