using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour {

    [Range(0f,400f)] public float base_hp;
    [SerializeField] private float current_hp;
    [SerializeField] private float delta;
    [SerializeField]private float invincibilityTime=1;

    public bool isBreakableObject;

    protected void Start() {
        current_hp = base_hp;

        if (isBreakableObject) { invincibilityTime = 0; }
        
    }

    void Update()
    {
        delta += Time.deltaTime;

    }

    public void modHp(float deltaHp) {
        if (delta >= invincibilityTime)
        {
            current_hp += deltaHp;
            if (current_hp <= 0) {
                onDeath();
                return;
            }
            if (deltaHp < 0) { //if damage is being done
                onHit();
            }

            delta = 0;

        }


    }

    virtual public void onDeath()
    {
        if (gameObject.Equals(Container.self.player))
        {
            SceneManager.LoadScene("Game Over");

        }
        Destroy(gameObject);
        Instantiate(Container.self.deathParticle, transform.position, transform.rotation);
    }

    virtual public void onHit()
    {
    }
}
