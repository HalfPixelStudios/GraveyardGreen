using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakableObject))]
public class VampireSpawnPoint : MonoBehaviour {

    private BreakableObject bo;

    private void Start() {
        bo = GetComponent<BreakableObject>();
    }

    private void Update() {
        if (bo.isBroken) {
            spawnVampire();
        }
    }

    public void spawnVampire() {
        GameObject new_vampire = Instantiate(Container.self.vampire, transform.position, Quaternion.identity);
        new_vampire.GetComponent<Enemy>().player = Container.self.player;
    }


}
