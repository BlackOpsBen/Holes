using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] float jumpMultiplier = 10f;
    bool isGrounded = false;

    // Box Cast info
    Vector2 origin = new Vector2(0f, -1f);
    Vector2 size = new Vector2(1.4f, 0.25f);
    RaycastHit2D hitInfo;
    [SerializeField] GameObject boxRef;

    void Update()
    {
        hitInfo = Physics2D.BoxCast(origin, size, 0f, Vector2.down, size.y);
        boxRef.transform.position = transform.position + Vector3.down;
        boxRef.transform.localScale = size;

        if (hitInfo)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        }
        if (!isGrounded && Input.GetButtonUp("Jump") && rb.velocity.y > float.Epsilon)
        {
            rb.velocity = Vector2.zero;
        }
    }

    //private bool isGrounded()
    //{
    //    if (hitInfo)
    //    {
    //        Debug.Log("Returning true!");
    //        return true;
    //    }
    //    else
    //    {
    //        Debug.Log("Returning FALSE!");
    //        return false;
    //    }
    //}
}
