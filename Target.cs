using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject playerObject;
    Transform player_transform;
    float distance = 0;

    int hp = 50;

    void Start()
    {
        playerObject = GameObject.Find("Body");
        player_transform = playerObject.GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        distance = Vector3.Distance(player_transform.position, transform.position);
        if(distance <= 15f){ 
            agent.SetDestination(player_transform.position);
        }
    } 
    
    public void TakeDamage(int dmg)
    { 
        hp = hp - dmg;
        print (hp);
    }
}
