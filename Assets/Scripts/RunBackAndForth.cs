using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackAndForth : MonoBehaviour
{
    [SerializeField] float speedMultiplier = .5f;
    bool isFacingLeft = false;

    private void Update()
    {
        if (!isFacingLeft)
        {
            transform.parent.transform.localPosition = transform.parent.transform.localPosition + Vector3.right * speedMultiplier;
        }
        else
        {
            transform.parent.transform.localPosition = transform.parent.transform.localPosition + Vector3.left * speedMultiplier;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFacingLeft = !isFacingLeft;
        transform.parent.transform.Rotate(0f, 180f, 0f);
    }
}
