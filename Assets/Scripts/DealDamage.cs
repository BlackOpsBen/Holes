using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] bool friendlyFire = true;
    public string friendlyType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            if (!friendlyFire && collision.GetComponentInChildren<DealDamage>())
            {
                if (friendlyType != collision.GetComponentInChildren<DealDamage>().friendlyType)
                {
                    collision.GetComponent<Health>().Damage(damage);
                }
            }
            else
            {
                collision.GetComponent<Health>().Damage(damage);
            }
        }
    }
}
