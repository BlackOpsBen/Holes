using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormholeOpenClose : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] ScaleView aViewB;
    [SerializeField] ScaleView bViewA;
    [SerializeField] Collider2D discColliderA;
    [SerializeField] Collider2D discColliderB;
    [SerializeField] float closedScale = float.Epsilon;
    [SerializeField] float openScale = 2f;
    [SerializeField] float enterScale = 10f;
    [SerializeField] float speedMultiplier = 10f;
    float t = 0.0f;
    bool isBusy = false;
    bool isResetting = false;
    bool isPlayerUsing = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isBusy)
        {
            MoveWormhole();
        }
        if (Input.GetMouseButton(0) && !isResetting && !isPlayerUsing)
        {
            OpenWormhole();
        }
        else if (!isPlayerUsing)
        {
            CloseWormhole();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isPlayerUsing)
            {
                t = 0.0f;
            }
            isPlayerUsing = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered Wormhole");
        if (collision.GetComponent<PlayerMove>())
        {
            StartCoroutine(ExpandForPlayerUse());
        }
    }

    private void MoveWormhole()
    {
        isBusy = true;
        float newXPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float newYPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y + GameManager.dimensionOffset * System.Convert.ToInt32(gameManager.GetisBCurrent());
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }

    private void OpenWormhole()
    {
        if (t > 0.5f)
        {
            discColliderA.enabled = true;
            discColliderB.enabled = true;
        }
        
        aViewB.scaleHole = Mathf.Lerp(closedScale, openScale, t);
        bViewA.scaleHole = Mathf.Lerp(closedScale, openScale, t);
        if (t < 1f)
        {
            t += 0.05f * Time.deltaTime * speedMultiplier;
        }
    }

    private void CloseWormhole()
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
            if (t < 0.5f)
            {
                discColliderA.enabled = false;
                discColliderB.enabled = false;
            }
            isBusy = false;
            isResetting = false;
        }
    }

    private IEnumerator ExpandForPlayerUse()
    {
        isPlayerUsing = true;
        ScaleView currentView = GetCurrentView();
        ScaleView oppositeView = GetOppositeView();
        oppositeView.scaleHole = 0.0f;
        float startScale = currentView.scaleHole;
        float t2 = 0f;
        while (t2 < 1f)
        {
            currentView.scaleHole = Mathf.Lerp(startScale, enterScale, t2);
            t2 += 0.05f * Time.deltaTime * speedMultiplier;
            yield return new WaitForEndOfFrame();
        }
        currentView.scaleHole = 0.0f;
        discColliderA.enabled = false;
        discColliderB.enabled = false;
    }

    private ScaleView GetCurrentView()
    {
        if (gameManager.GetisBCurrent())
        {
            return aViewB;
        }
        else
        {
            return bViewA;
        }
    }

    private ScaleView GetOppositeView()
    {
        if (gameManager.GetisBCurrent())
        {
            return bViewA;
        }
        else
        {
            return aViewB;
        }
    }
}
