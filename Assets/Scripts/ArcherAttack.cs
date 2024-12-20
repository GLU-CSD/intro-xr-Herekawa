using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{

    [SerializeField] float dmgAmount = 10f;       // Schade per aanval
    [SerializeField] float atkCooldown = 2f;      // Tijd tussen aanvallen
    private float lastAttackTime;          // Tijd sinds laatste aanval
    private Health baseHealth;       // Referentie Health script base
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Base"))
        // Zorg dat de base de tag "Base" heeft
        {
            baseHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            baseHealth = null;
            // Verwijdert de referentie wanneer de vijand de base verlaat
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + atkCooldown)
        {
            baseHealth.TakeDamage(dmgAmount); // Schade doen aan de base
            lastAttackTime = Time.time; // Tijd van laatste aanval bijwerken
                                        //Debug.Log(this.name + "attacked the base!");
        }
    }
}
