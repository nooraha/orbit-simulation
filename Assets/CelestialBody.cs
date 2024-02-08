using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void UpdateGravity(CelestialBody[] celestials)
    {
        foreach(CelestialBody otherBody in celestials)
        {
            if (otherBody != this)
            {
                float sqrDist = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
                Vector3 force = forceDir * OrbitPhysics.bigG * rb.mass * otherBody.rb.mass / sqrDist;
                rb.AddForce(force);
            }
        }
    }

    public void CalculateInitialVelocity(CelestialBody[] celestials)
    {
        foreach(CelestialBody otherBody in celestials)
        {
            if(otherBody != this)
            {
                float m2 = otherBody.rb.mass;
                float r = Vector3.Distance(transform.position, otherBody.transform.position);

                transform.LookAt(otherBody.transform);
                rb.velocity += transform.right * Mathf.Sqrt(OrbitPhysics.bigG * m2 / r);
            }
        }
    }
}
