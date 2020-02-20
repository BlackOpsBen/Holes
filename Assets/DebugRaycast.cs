using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRaycast : MonoBehaviour
{
    Transform player;
    Vector2 mousePos;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(player.position, mousePos);
        if (hit)
        {
            if (Vector2.Distance(player.position, hit.point) < Vector2.Distance(player.position, mousePos))
            {
                Debug.Log(hit.collider.name);
                Debug.DrawLine(player.position, hit.point);
            }
            else
            {
                Debug.Log("Mouse closer than hit.");
                Debug.DrawLine(player.position, mousePos);
            }
        }
        else
        {
            Debug.Log("No hit.");
            Debug.DrawLine(player.position, mousePos);
        }
    }
}
