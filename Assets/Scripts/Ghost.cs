using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField]private float verticalDelta;
    [SerializeField]private float ay;

    float vy=0;
    private float initY;

    private Enemy _enemy;
    

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        initY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < initY)
        {
            ay = Mathf.Abs(ay);
        }
        else if (transform.position.y > initY + verticalDelta)
        {
            ay = -Mathf.Abs(ay);
        }

        vy += ay;
        vy = Mathf.Clamp(vy, -speed, speed);

        transform.position += new Vector3(0,vy,0);
        
        if (!_enemy.attack&&_enemy.detected)
        {
            transform.LookAt(_enemy.player.transform);
            transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
            transform.position+=transform.forward * speed;
            //Debug.Log(transform.forward*3);
        }


    }
}
