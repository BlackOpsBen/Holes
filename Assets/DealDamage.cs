using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] BoxCollider2D damageContact;
    [SerializeField] int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.collider.name);
        if (collision.otherCollider == damageContact && collision.collider.GetComponent<Health>())
        {
            collision.collider.GetComponent<Health>().Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by " + collision.name);
    }
}
