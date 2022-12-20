using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public const float gravity = -0.1f;
    public float heatSourceY = -0.5f;
    public float temperature = 0f;

    public Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition += (velocity * Time.deltaTime);
        if (transform.localPosition.y < heatSourceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, heatSourceY, transform.localPosition.z);
        }
        
    }
}
