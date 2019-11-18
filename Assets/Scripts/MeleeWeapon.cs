using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(GrabableObject))]
public class MeleeWeapon : Timer {

    [Range(0f, 50f)] public float damage;

    private GrabableObject go;

    public AudioClip[] attack_sounds;

    void Start() {
        base.Start();

        go = GetComponent<GrabableObject>();
    }

    void Update() {
        base.Update();
    }

    private void OnTriggerEnter(Collider other) {
        HealthComponent hc = other.gameObject.GetComponent<HealthComponent>();
        if (hc != null && other.gameObject != transform.root && isActive) { //if the contact object can be hit and collided object isnt owner
            hc.modHp(-damage);
            //Debug.Log("HIT");

        }

    }

    public override void activateEffect() {
        base.activateEffect();
        Assert.IsNotNull(go.owner.GetComponent<Animator>());
        go.owner.GetComponent<Animator>().SetBool("isAttacking",true);
    }

    public override void deactivateEffect() {
        base.deactivateEffect();
        Assert.IsNotNull(go.owner.GetComponent<Animator>());
        go.owner.GetComponent<Animator>().SetBool("isAttacking", false);
    }
}
