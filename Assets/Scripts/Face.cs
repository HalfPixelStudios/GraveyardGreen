using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy _enemy;
    void Start()
    {
        _enemy = transform.parent.gameObject.GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0,_enemy.angleToPlayer*Mathf.Rad2Deg,0);
        
        
    }
}
