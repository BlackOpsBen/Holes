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
    [SerializeField] float closedScale = 0f;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
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
        discColliderA.enabled = true;
        discColliderB.enabled = true;
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
            discColliderA.enabled = false;
            discColliderB.enabled = false;
            isBusy = false;
            isResetting = false;
        }
    }

    private IEnumerator ExpandForPlayerUse()
    {
        isPlayerUsing = true;
        ScaleView currentView = GetCurrentView();
        float startScale = currentView.scaleHole;
        float t2 = 0f;
        while (t2 < 1f)
        {
            currentView.scaleHole = Mathf.Lerp(startScale, enterScale, t2);
            t2 += 0.05f * Time.deltaTime * speedMultiplier;
            Debug.Log("t2 value: " + t2);
            yield return null;
        }
        isPlayerUsing = false;
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
}
