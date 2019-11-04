using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    private NavMeshAgent agent;

    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemy.attack&&_enemy.detected)
        {
            agent.SetDestination(_enemy.player.transform.position);
            
        }
        else
        {
            agent.ResetPath();
        }
        

    }
}
