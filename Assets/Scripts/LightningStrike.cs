using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider nearbyObject in colliders)
        {
            Health targetHealth = nearbyObject.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(30f);
            }
        }
        Destroy(gameObject, 0.4f);
    }
}


