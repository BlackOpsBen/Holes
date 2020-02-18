using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeOpenClose : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] ScaleView aViewB;
    [SerializeField] ScaleView bViewA;
    [SerializeField] float closedScale = 0f;
    [SerializeField] float openScale = 2f;
    [SerializeField] float enterScale = 10f;
    [SerializeField] float speedMultiplier = 10f;
    float t = 0.0f;
    bool isBusy = false;
    bool isResetting = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isBusy)
        {
            isBusy = true;
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + GameManager.dimensionOffset * System.Convert.ToInt32(gameManager.GetisBCurrent()), transform.position.z);
        }
        if (Input.GetMouseButton(0) && !isResetting)
        {
            aViewB.scaleHole = Mathf.Lerp(closedScale, openScale, t);
            bViewA.scaleHole = Mathf.Lerp(closedScale, openScale, t);
            if (t < 1f)
            {
                t += 0.05f * Time.deltaTime * speedMultiplier;
            }
        }
        else
        {
            aViewB.scaleHole = Mathf.Lerp(closedScale, openScale, t);
            bViewA.scaleHole = Mathf.Lerp(closedScale, openScale, t);
            if (t > float.Epsilon)
            {
                isResetting = true;
                t -= 0.05f * Time.deltaTime * speedMultiplier;
            }
            else
            {
                isBusy = false;
                isResetting = false;
            }
        }
    }

    //private ScaleView GetCurrentView()
    //{
    //    if (gameManager.GetisBCurrent())
    //    {
    //        return aViewB;
    //    }
    //    else
    //    {
    //        return bViewA;
    //    }
    //}
}
