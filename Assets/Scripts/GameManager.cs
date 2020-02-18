using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;

    bool isBCurrent = false;

    public static float dimensionOffset = 40f;

    private void Start()
    {
        mainCamera = GameObject.Find("MainCam").GetComponent<Camera>();
    }

    private void Update()
    {
        if (mainCamera.transform.position.y < -GameManager.dimensionOffset/2)
        {
            isBCurrent = true;
        }
        else
        {
            isBCurrent = false;
        }
    }

    public bool GetisBCurrent()
    {
        return isBCurrent;
    }
}
