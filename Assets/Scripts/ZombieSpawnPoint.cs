using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour {
    public GameObject spawn_particle;
    public float timer=0;

    //public GameObject spawnpoint;
    public Vector3 spawn_offset;

    private float spawn_duration;

    void spawnFunction()
    {
        
        
    }
    

    void Start() {
        //Debug.Log(gameObject);
        spawn_duration = Random.Range(20f, 30f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawn_duration)
        {
            spawn();
            timer = 0;
            spawn_duration = Random.Range(20f, 30f);

        }

    }

    void spawn()
    {
       
        Quaternion direct = Quaternion.Euler(0,Random.Range(0,360),0);
        //Vector3 spawnpoint = transform.localPosition + spawn_offset;
        GameObject new_zombie = Instantiate(Container.self.zombie,transform.position,direct);
        //new_zombie.GetComponent<Rigidbody>().isKinematic = true;
        new_zombie.GetComponent<Enemy>().player = Container.self.player;
        new_zombie.GetComponent<Rigidbody>().AddForce(0,0,-5,ForceMode.Impulse);
        
    }
}
