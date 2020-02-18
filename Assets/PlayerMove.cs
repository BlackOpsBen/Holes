using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float xAxis;
    float yAxis;
    [SerializeField] float minMultiplier = 1f;
    [SerializeField] float maxMultiplier = 5f;
    [SerializeField] float multiplierIncrement = 5f;
    float currentMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + xAxis * currentMultiplier * Time.deltaTime, transform.position.y + yAxis * currentMultiplier * Time.deltaTime, transform.position.z);

        if (Input.GetKey(KeyCode.LeftShift) && currentMultiplier < maxMultiplier)
        {
            currentMultiplier += multiplierIncrement * Time.deltaTime;
        }
        else if (currentMultiplier > minMultiplier)
        {
            currentMultiplier -= multiplierIncrement * Time.deltaTime;
        }
    }
}
