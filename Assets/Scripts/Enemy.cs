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
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float dist=Mathf.Sqrt(Mathf.Pow(transform.position.x-player.transform.position.x,2)+Mathf.Pow(transform.position.y-player.transform.position.y,2));
        angleToPlayer = Mathf.Atan2(player.transform.position.y-transform.position.y, player.transform.position.x-transform.position.x);
        if (checkVisible(dist))
        {
            detected = true;
        }
        else
        {
            if (detected)
            {
                gameObject.GetComponent<Rigidbody>().velocity=Vector2.zero;
            }
            detected = false;
            //just in case sight is greater than attack for some stupid reason
            anim.SetBool("isAttacking", false);
        }

        if (dist < attack_range)
        {
            
            anim.SetBool("isAttacking", true);




        }
        else
        {
            attack = false;
        }

    }

    public bool checkVisible(float dist)
    {
        RaycastHit hit;
        Vector3 center=new Vector3(transform.position.x,transform.position.y+centerY,transform.position.z);
        if (needsSight)
        {
            Debug.DrawRay(center,transform.forward*sight , Color.green);
            if(Physics.CapsuleCast(center,center,2,transform.forward*sight,out hit))
            {
                print("Hit");
            
                return hit.collider.gameObject == player;
            }
            else
            {
                return dist<sight&&detected;
            }
            
        }

        return dist<sight;

    }
}