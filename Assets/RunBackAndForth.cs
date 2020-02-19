using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackAndForth : MonoBehaviour
{
    [SerializeField] float speedMultiplier = .5f;
    [SerializeField] BoxCollider2D wallHitCollider;
    bool isFacingLeft = false;

    private void Update()
    {
        if (!isFacingLeft)
        {
            transform.localPosition = transform.localPosition + Vector3.right * speedMultiplier;
        }
        else
        {
            transform.localPosition = transform.localPosition + Vector3.left * speedMultiplier;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider == wallHitCollider)
        {
            isFacingLeft = !isFacingLeft;
            Debug.Log("Collided with " + collision.gameObject.name);
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
