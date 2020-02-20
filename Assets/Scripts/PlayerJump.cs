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
    RaycastHit2D hitInfo;

    void Update()
    {
        Vector2 size = new Vector2(col.bounds.size.x * 0.9f, 0.25f);
        Vector3 castFrom = new Vector3(col.bounds.center.x, col.bounds.center.y - col.bounds.size.y / 2f - 0.26f, col.bounds.center.z);
        hitInfo = Physics2D.BoxCast(castFrom, size, 0f, Vector2.down, 0.25f);

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
}
