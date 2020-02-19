using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    bool isFacingLeft = false;
    float stickThreshold = 0.1f;

    public bool isBusy = false;

    float horizontalAxis;
    float horizontalAxisRaw;

    float verticalAxis;
    float verticalAxisRaw;

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        horizontalAxisRaw = Input.GetAxisRaw("Horizontal");

        transform.position = transform.position + new Vector3(horizontalAxis * Time.deltaTime * moveSpeed, 0f, 0f);
        FaceDirection();
    }

    private void FaceDirection()
    {
        if (horizontalAxisRaw < -stickThreshold)
        {
            if (!isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = true;
            }
        }
        else if (horizontalAxisRaw > stickThreshold)
        {
            if (isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = false;
            }
        }
    }
}
