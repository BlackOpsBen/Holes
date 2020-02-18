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
    bool isOpening = false;
    bool isClosing = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(OpenWormHole());
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(CloseWormHole());
        }
    }

    private IEnumerator OpenWormHole()
    {
        while (isClosing)
        {
            yield return null;
        }
        isOpening = true;
        ScaleView scaleView;
        scaleView = GetCurrentView();
        float t = 0.0f;
        while (t < 1f)
        {
            scaleView.scaleHole = Mathf.Lerp(closedScale, openScale, t);
            t += 0.05f * Time.deltaTime * speedMultiplier;
            yield return null;
        }
        isOpening = false;
    }

    private IEnumerator CloseWormHole()
    {
        while (isOpening)
        {
            yield return null;
        }
        isClosing = true;
        ScaleView scaleView;
        scaleView = GetCurrentView();
        float t = 0.0f;
        while (t < 1f)
        {
            scaleView.scaleHole = Mathf.Lerp(openScale, closedScale, t);
            t += 0.05f * Time.deltaTime * speedMultiplier;
            yield return null;
        }
        isClosing = false;
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
