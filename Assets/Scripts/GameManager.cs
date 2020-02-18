using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isBCurrent = false;

    public static float dimensionOffset = 40f;

    public bool GetisBCurrent()
    {
        return isBCurrent;
    }
}
