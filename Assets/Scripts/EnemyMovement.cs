using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    [SerializeField] private bool isRanged;

    //[SerializeField] GameManager gameManager;
    void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Base");


        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        float dist = float.PositiveInfinity;
        Vector3 pos = this.transform.position;
        Transform target = null;
        HashSet<GameObject> targetNodes = null;
        if (isRanged)
        {
            targetNodes = GameManager.RangerNodes;
        }
        else
        {
            targetNodes = GameManager.TargetNodes;
        }

        foreach (GameObject obj in targetNodes)
        {
            var d = (pos - obj.transform.position).sqrMagnitude;
            if (d < dist)
            {
                target = obj.transform;
                dist = d;
            }
        }

        // Beweeg naar de positie van de speler als deze is gevonden
        if (target != null && agent.isOnNavMesh)
        {
            agent.SetDestination(target.position);
        }
    }
}

