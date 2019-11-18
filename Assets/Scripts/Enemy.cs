using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool detected = false;
    public bool attack = false;
    public float attack_range;
    public float sight;
    public float reloadTime;
    public float angleToPlayer=0;
    //this is set to true if the zombie needs to see to follow the player
    public bool needsSight;
    public float centerY;

    public GameObject player;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        player= Container.self.player;
        
        float dist=Mathf.Sqrt(Mathf.Pow(transform.position.x-player.transform.position.x,2)+Mathf.Pow(transform.position.z-player.transform.position.z,2));
        angleToPlayer = Vector2.Angle(new Vector2(transform.forward.x, transform.forward.z),
            new Vector2(player.transform.position.x - transform.position.x,
                player.transform.position.z - transform.position.z));
        if (checkVisible(dist))
        {
            detected = true;
        }
        else
        {
            detected = false;
        }
        if(dist<attack_range&&detected)
        {
            attack = true;
            
        }
        else
        {
            attack = false;
        }

    }

    public bool checkVisible(float dist)
    {
        
        if (needsSight&&!detected)
        {
            return dist < sight && angleToPlayer < 30;
            
        }
        return dist < sight;








    }
}