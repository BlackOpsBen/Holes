using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleView : MonoBehaviour
{
    [SerializeField] GameObject disc;
    [Range(0, 100)]
    public float scaleHole = 1f;
    float discDefaultScale = 30f;
    float cameraDefaultSize = 1.5f;
    // Update is called once per frame
    void Update()
    {
        disc.transform.localScale = new Vector3(discDefaultScale * scaleHole, discDefaultScale * scaleHole, 100f);
        this.GetComponent<Camera>().orthographicSize = cameraDefaultSize * scaleHole;
    }
}
