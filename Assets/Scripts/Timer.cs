using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [Range(0f, 10f)] public float cooldown;
    [Range(0f, 10f)] public float duration;

    [SerializeField] protected float cooldown_counter;
    [SerializeField] protected float duration_counter;

    public bool isActive;

    protected void Start() {
        isActive = false;
        cooldown_counter = cooldown;
        duration_counter = duration;
    }

    protected void Update() {
        
        if (isActive == true && duration_counter > 0) {
            duration_counter -= Time.deltaTime;
            passiveEffect();
        }

        if (isActive == false && cooldown_counter > 0) {
            cooldown_counter -= Time.deltaTime;
        }

        if (duration_counter <= 0) {
            isActive = false;
            deactivateEffect();
        }

        
    }

    public virtual void activate() {
        if (cooldown_counter > 0 || isActive) { return; }
        cooldown_counter = cooldown;
        duration_counter = duration;
        isActive = true;
        activateEffect();
    }

    public virtual void activateEffect() { }

    public virtual void passiveEffect() { }

    public virtual void deactivateEffect() { }

}
