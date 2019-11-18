using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : HealthComponent {

    public GameObject hit_particle;
    public GameObject kill_particle;

    public AudioClip[] hit_sounds;
    public AudioClip[] kill_sounds;

    public override void onDeath() {

        //TODO: DEath particle effects and sounds
        if (kill_particle != null) {
            Instantiate(kill_particle, transform.position, transform.rotation);
        }

        if (kill_sounds.Length > 0) {
            TempSoundPlayer sp = (Instantiate(Resources.Load("TempSoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<TempSoundPlayer>();
            AudioClip kill_clip = kill_sounds[Random.Range(0, kill_sounds.Length)];
            sp.playSound(kill_clip);
        }


        Destroy(this.gameObject);


    }

    public override void onHit() {

        //TODO: Hit particle effects and sounds
        if (hit_particle != null) {
            Instantiate(hit_particle, transform.position, transform.rotation);
        }

        if (hit_sounds.Length > 0) {
            TempSoundPlayer sp = (Instantiate(Resources.Load("TempSoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<TempSoundPlayer>();
            AudioClip hit_clip = hit_sounds[Random.Range(0, hit_sounds.Length)];
            sp.playSound(hit_clip);
        }

    }
}
