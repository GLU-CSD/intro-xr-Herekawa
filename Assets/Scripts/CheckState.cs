using UnityEngine;

using Unity.XR.CoreUtils;

public class BaseState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Health health;

    private void Update()
    {
        if (health != null)
        {
            if (gameManager != null)
            {
                if (health.currentHealth <= 0)
                {
                    gameManager.GameOver();
                    gameObject.GetNamedChild("DestroyedBase").GetComponent<MeshRenderer>().enabled = true;
                    gameObject.GetNamedChild("HealthyBase").GetComponent<MeshRenderer>().enabled = false;

                    //gameObject.GetNamedChild("HealthyBase").SetActive(false);

                }
            }
            else
            {
                Debug.Log("Base has no reference to GameManager");
            }

        }
        else
        {
            Debug.Log("Base has no reference to Health");
        }
    }
}