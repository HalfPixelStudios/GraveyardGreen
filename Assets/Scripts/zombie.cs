using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    private NavMeshAgent agent;

    private Enemy _enemy;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();


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
        //Debug.Log(_enemy.attack);

        _animator.SetBool("isAttacking",_enemy.attack);
        _animator.SetBool("detected", _enemy.detected);




    }
}
