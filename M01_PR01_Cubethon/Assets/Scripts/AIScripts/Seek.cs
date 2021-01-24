using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;

    public float maxSpeed = 5f;

    void Update()
    {
        KinematicSteeringOutput steeringOutput = GetSteeringOutput();
        transform.position += steeringOutput.velocity * Time.deltaTime;
    }

    public KinematicSteeringOutput GetSteeringOutput()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.position - this.transform.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        float orientationAngle = newOrientation(transform.eulerAngles.y, result.velocity);
        this.transform.eulerAngles = new Vector3(0, orientationAngle * (180 / Mathf.PI), 0);

        result.rotation = 0;
        return result;
    }

    public float newOrientation(float currOrAngle, Vector3 vel)
    {
        if (vel.magnitude > 0)
            return Mathf.Atan2(vel.x, vel.z);
        else
            return currOrAngle;

    }
}
