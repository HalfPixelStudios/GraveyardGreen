using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BreakableObject : HealthComponent {

    public bool disable_collision_on_death;

    public GameObject intact_state;
    public GameObject broken_state;

    public GameObject hit_particle;
    public GameObject kill_particle;

    public AudioClip[] hit_sounds;
    public AudioClip[] kill_sounds;

    public List<GameObject> drop_table;

    public bool isBroken = false;

    void Start() {
        base.Start();

        intact_state.SetActive(true);
        broken_state.SetActive(false);
    }

    void Update() {
        
    }

    public override void onDeath() {
        intact_state.SetActive(false);
        broken_state.SetActive(true);

        //TODO: DEath particle effects and sounds
        if (kill_particle != null) {
            Instantiate(kill_particle, transform.position, transform.rotation);
        }

        if (kill_sounds.Length > 0) {
            TempSoundPlayer sp = (Instantiate(Resources.Load("TempSoundPlayer"), transform.position, transform.rotation) as GameObject).GetComponent<TempSoundPlayer>();
            AudioClip kill_clip = kill_sounds[Random.Range(0, kill_sounds.Length)];
            sp.playSound(kill_clip);
        }

        //Drop some items
        if (drop_table.Count > 0) {
            int ind = Random.Range(0, drop_table.Count - 1);
            Instantiate(drop_table[ind],transform.position,Quaternion.identity);
        }

        if (disable_collision_on_death) {
            GetComponent<Collider>().enabled = false;
        }

        GameObject gh=Instantiate(Container.self.ghost, transform);
        gh.GetComponent<Enemy>().player = Container.self.player;

        isBroken = true;
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
