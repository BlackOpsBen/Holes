using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    bool isADestination = false;
    bool isCoolingDown = false;

    private void Update()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        if (transform.position.y < -GameManager.dimensionOffset / 2)
        {
            isADestination = true;
        }
        else
        {
            isADestination = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCoolingDown)
        {
            if (GetComponent<PlayerMover>())
            {
                StartCoroutine(PlayerDelayedWarp());
            }
            else
            {
                WarpToOtherPoint();
            }
        }
    }

    private void WarpToOtherPoint()
    {
        isCoolingDown = true;
        if (isADestination)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + GameManager.dimensionOffset, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - GameManager.dimensionOffset, transform.position.z);
        }
        StartCoroutine(EndCoolDown());
    }

    private IEnumerator PlayerDelayedWarp()
    {
        yield return new WaitForSeconds(0.1f);
        WarpToOtherPoint();
    }

    private IEnumerator EndCoolDown()
    {
        yield return new WaitForSeconds(.1f);
        isCoolingDown = false;
    }
}
