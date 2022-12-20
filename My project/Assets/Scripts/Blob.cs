using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public const float gravity = -0.1f;
    public const float minYSpeed = -1;
    public float heatSourceY = -0.5f;
    public float temperature = 0f;
    public Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        velocity += new Vector3(0f, gravity*Time.deltaTime, 0f);
        if(velocity.y < minYSpeed)
        {
            velocity = new Vector3(velocity.x, minYSpeed, velocity.z);
        }
        transform.localPosition += transform.localPosition + (velocity * Time.deltaTime); 
        if (transform.localPosition.y < heatSourceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, heatSourceY, transform.localPosition.z);
            if (velocity.y <0f)
            {
                velocity = new Vector3(velocity.x, 0f, velocity.z);
            }
        }
    }
}
