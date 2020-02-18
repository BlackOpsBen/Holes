using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
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
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        horizontalAxisRaw = Input.GetAxisRaw("Horizontal");

        verticalAxis = Input.GetAxis("Vertical");
        verticalAxisRaw = Input.GetAxisRaw("Vertical");

        // Move the player
        transform.position = transform.position + new Vector3(horizontalAxis * Time.deltaTime * moveSpeed, verticalAxis * Time.deltaTime * moveSpeed, 0f);

        // New flip behavior
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
