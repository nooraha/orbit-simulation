using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPhysics : MonoBehaviour
{
    public const float bigG = 100f;
    CelestialBody[] celestials;

    // Start is called before the first frame update
    void Start()
    {
        celestials = FindObjectsOfType<CelestialBody>();
        foreach (CelestialBody body in celestials)
        {
            body.CalculateInitialVelocity(celestials);
        }
    }


    private void FixedUpdate()
    {
        foreach(CelestialBody body in celestials)
        {
            body.UpdateGravity(celestials);
        }
    }
}
