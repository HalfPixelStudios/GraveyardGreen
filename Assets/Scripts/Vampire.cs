using System;
using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    [SerializeField] private float delta,diveInterval,speed;

    private bool diving=false;
    private float initHeight;
    private Vector3 upDir;
    
    // Start is called before the first frame update
    void Start()
    {

        initHeight = transform.position.y;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Container.self.player.transform);
        
        if (diving)
        {
            transform.position += transform.forward * speed;

        }
        else if(!diving&&transform.position.y>=initHeight)
        {
            delta += Time.deltaTime;
            
            if (delta > diveInterval)
            {
                diving = true;
            
                delta = 0;
            } 
        }
        else
        {
            
            transform.position += upDir;
        }
        
        
    }
    

    private void OnCollisionEnter(Collision other)
    {
        upDir=new Vector3(transform.forward.x,0.2f,transform.forward.z);
        diving = false;
        
    }
}
