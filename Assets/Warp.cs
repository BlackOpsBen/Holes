using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    bool isBClosest = false;

    private void Update()
    {
        if (transform.position.y < -GameManager.dimensionOffset / 2)
        {
            isBClosest = true;
        }
        else
        {
            isBClosest = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            WarpToOtherPoint();
        }
    }

    private void WarpToOtherPoint()
    {
        if (isBClosest)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + GameManager.dimensionOffset, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - GameManager.dimensionOffset, transform.position.z);
        }
    }
}
