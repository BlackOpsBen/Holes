using UnityEngine;

[ExecuteInEditMode]
public class dimensionOffset : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0f - GameManager.dimensionOffset, transform.localPosition.z);
    }
}
