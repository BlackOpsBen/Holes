using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameras : MonoBehaviour
{
    [SerializeField] Transform playerA;
    [SerializeField] Transform playerB;
    Transform currentAB;
    // Start is called before the first frame update
    void Start()
    {
        currentAB = playerA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = currentAB.position;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SwapCamera();
        }
    }

    public void SwapCamera()
    {
        if (currentAB == playerA)
        {
            currentAB = playerB;
        }
        else
        {
            currentAB = playerA;
        }
    }

    public bool isBActive()
    {
        if(currentAB == playerB)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
