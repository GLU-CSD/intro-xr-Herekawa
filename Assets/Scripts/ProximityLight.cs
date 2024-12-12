using UnityEngine;

public class ProximityLight : MonoBehaviour
{
    [SerializeField] private Light proxLight;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Geef de XR Rig de tag "Player"
        {
            proxLight.enabled = true;
            Debug.Log("Licht aan");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            proxLight.enabled = false;
            Debug.Log("Licht uit");
        }
    }
}