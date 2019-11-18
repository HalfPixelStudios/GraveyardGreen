using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : Timer {

    private Light light;

    public float intensity;

    void Start() {
        base.Start();

        light = GetComponent<Light>();

    }

    public override void activate() {
        cooldown = Random.Range(0.1f,0.2f);
        duration = Random.Range(0.2f,1.2f);

        base.activate();
    }

    public override void activateEffect() {
        light.intensity = intensity;
    }

    public override void deactivateEffect() {
        light.intensity = 0;
        activate();
    }
}
