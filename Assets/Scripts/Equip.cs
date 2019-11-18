using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

    //public bool equipping=false;
    public GameObject equipped;

    public GameObject grabPoint;

    private Animator anim;

    public AudioClip pickup_sound;
    public AudioClip drop_sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("isAttacking",false);
    }

    // Update is called once per frame
    void Update()
    {
        //Attack
        if (Input.GetMouseButtonDown(0) && equipped != null && equipped.GetComponent<MeleeWeapon>() != null) {
            MeleeWeapon w = equipped.GetComponent<MeleeWeapon>();


            w.activate();

            //if (!w.isActive) { w.activate(); }
        }

        //Unequip
        if (Input.GetMouseButtonDown(1) && equipped != null) {
            equipped.transform.parent = null;
            GrabableObject go = equipped.GetComponent<GrabableObject>();
            go.owner = null;
            go.reset_y_position();
            equipped.transform.localRotation = Quaternion.identity;
            equipped = null;
            anim.SetBool("isHolding", false);

            //play sound
            TempSoundPlayer sp = (Instantiate(Resources.Load("TempSoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<TempSoundPlayer>();
            sp.setVolume(0.2f);
            sp.playSound(drop_sound);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<GrabableObject>() != null && equipped == null)
        {
            equipped = other.gameObject;
            equipped.transform.parent = grabPoint.transform;
            GrabableObject go = other.gameObject.GetComponent<GrabableObject>();
            equipped.transform.localPosition = go.position_offset;
            equipped.transform.localRotation = go.rotation_offset;
            go.owner = this.gameObject;
            //equipped.GetComponent<CapsuleCollider>().enabled = false;
            if (go.two_hand_hold) { anim.SetBool("isHolding",true); }

            //play sound
            TempSoundPlayer sp = (Instantiate(Resources.Load("TempSoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<TempSoundPlayer>();
            sp.setVolume(0.2f);
            sp.playSound(pickup_sound);


        }
        
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
