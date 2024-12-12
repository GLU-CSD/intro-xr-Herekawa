using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Explode();
        }
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
            
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(500f, transform.position, 3f);
            }
        }
        
        Destroy(gameObject);
    }
}