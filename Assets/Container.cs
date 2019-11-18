using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject player;
    public GameObject ghost;
    public GameObject zombie;
    public GameObject vampire;
    public static Container self;
    public Material outline;
    public ParticleSystem deathParticle;
    
    void Start()
    {
        self = this;


    }
    
    void Update()
    {
        
    }
}
