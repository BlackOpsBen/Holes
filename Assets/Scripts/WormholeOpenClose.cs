using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeOpenClose : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] ScaleView aViewB;
    [SerializeField] ScaleView bViewA;
    [SerializeField] float closedScale = 0f;
    [SerializeField] float openScale = 2f;
    [SerializeField] float enterScale = 10f;
    /* On DOWN, open
     * On UP, close
     * 
     */
    private void Start()
    {
        mainCamera = FindObjectOfType<SwapCameras>().GetComponent<Camera>();

    }

    private void Update()
    {
        
    }
}
