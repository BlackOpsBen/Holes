using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{
    float BOffset = 20f;
    [SerializeField] SwapCameras swapCameras;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + BOffset * System.Convert.ToInt32(swapCameras.isBActive()) , transform.position.z);
        }
    }
}
