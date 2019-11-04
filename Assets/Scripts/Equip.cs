using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public bool equipping=false;
    public GameObject equipped;

    public GameObject grabPoint;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (equipping&&other.GetComponent<GrabableObject>() != null)
        {
            
            equipped = other.gameObject;
            equipped.transform.parent = grabPoint.transform;
            GrabableObject go = other.gameObject.GetComponent<GrabableObject>();
            equipped.transform.localPosition = go.position_offset;
            equipped.transform.localRotation = go.rotation_offset;
            equipped.GetComponent<CapsuleCollider>().enabled = false;
            

        }
        
    }
}
