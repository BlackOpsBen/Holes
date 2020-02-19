using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] float jumpMultiplier = 10f;
    void Update()
    {
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        }
        if (!isGrounded() && Input.GetButtonUp("Jump") && rb.velocity.y > float.Epsilon)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.BoxCast(col.bounds.center, new Vector2(1, 1), 0f, Vector2.down))
        {
            Debug.Log("Returning true!");
            return true;
        }
        else
        {
            Debug.Log("Returning FALSE!");
            return false;
        }
    }
}
