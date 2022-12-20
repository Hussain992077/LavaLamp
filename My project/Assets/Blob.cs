using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public float gravity = 0.1f;
    public float maxYSpeed =1f;
    
    public float heatSourceY = -0.5f;
    public float heatSourceIntensity = 1;
    public float passiveCoolingRate = 0.5f;
    
    public float temperatureForce = 0.01f;
    public float minTemperature = 0f;
    public float maxTemperature = 100f;
    public float temperatureMinScale = 0.1f;
    public float temperatureMaxScale = 0.5f;


    public float temperature = 0f;

    public Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply heating
        float distToHeatSource = Mathf.Abs(transform.localPosition.y - heatSourceY);
        float heatInFluence = (1f-distToHeatSource) * (1f-distToHeatSource);
        temperature += (heatInFluence - passiveCoolingRate) * Time.deltaTime;
        temperature = Mathf.Clamp(temperature,minTemperature,maxTemperature);
        //temprature and gravity affect our Y speed
        float ySpeedDelta = (temperature*temperatureForce - gravity) * Time.deltaTime;
        float ySpeed = Mathf.Clamp(velocity.y + ySpeedDelta, -maxYSpeed, maxYSpeed);
        velocity = new Vector3(velocity.x, ySpeed, velocity.z);
        //move according to current velocity
        transform.localPosition += (velocity * Time.deltaTime);
        //stop if we hit the bottom
        if (transform.localPosition.y < heatSourceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, heatSourceY, transform.localPosition.z);

            if (velocity.y < 0f)
            {
                velocity = new Vector3(velocity.x, 0f, velocity.z);
            }
        }
        if (transform.localPosition.y > -heatSourceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, heatSourceY, transform.localPosition.z);

            if (velocity.y > 0f)
            {
                velocity = new Vector3(velocity.x, 0f, velocity.z);
            }
        }
        
    }
}
