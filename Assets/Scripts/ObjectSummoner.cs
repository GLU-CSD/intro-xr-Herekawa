using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjSummoner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;       // Het object dat je wilt spawnen
    [SerializeField] Transform SummonPos;
    [SerializeField] TextMeshProUGUI ChargesUI;
    [SerializeField] Image CooldownUI;

    [SerializeField] int maxcharges;
    [SerializeField] float cooldownTime;

    private int charges = 0;
    private float lastCharge = 0f;

    void Start()
    {
        updateBombsUI();
    }

    public void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            if (charges > 0)
            {
                var spawnedObj = Instantiate(objectToSpawn, SummonPos.position, SummonPos.rotation);
                spawnedObj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3,3),0,Random.Range(-3,3)));
                if (charges == maxcharges)
                {
                    lastCharge = Time.time;
                }
                charges--;
                updateBombsUI();
            }
        }
        else
        {
            Debug.LogWarning("Object to spawn is not set.");
        }
    }

    private void updateBombsUI()
    {
        ChargesUI.text = charges + " / " + maxcharges;
    }
    void Update()
    {
        if (charges < maxcharges)
        {
            CooldownUI.fillAmount = (Time.time-lastCharge)/cooldownTime;
            
            if (Time.time > lastCharge+cooldownTime)
            {
                lastCharge = Time.time;
                charges ++;
                updateBombsUI();
            }
        } else
        {
            CooldownUI.fillAmount = 1f;
        }
        
    }
}