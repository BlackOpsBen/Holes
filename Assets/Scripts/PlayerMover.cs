﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    bool isFacingLeft = false;
    float stickThreshold = 0.1f;

    public bool isBusy = false;

    float movementAxis;
    float movementAxisRaw;

    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxis = Input.GetAxis("Horizontal");
        movementAxisRaw = Input.GetAxisRaw("Horizontal");
        
        // Move the player left and right
        if (!isBusy && (movementAxis > stickThreshold || movementAxis < -stickThreshold))
        {
            transform.position = transform.position + new Vector3(movementAxis * Time.deltaTime * moveSpeed, 0f, 0f);
        }

        // New flip behavior
        if (movementAxisRaw < -stickThreshold)
        {
            if (!isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = true;
            }
        }
        else if (movementAxisRaw > stickThreshold)
        {
            if (isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = false;
            }
        }

    }
}