using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;
    private Equip equip;

    [Range(-10f,10f)] public float speed;

    Vector3 prev_pos;

    //private float prev_angle;
    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        equip = GetComponent<Equip>();
        anim.SetBool("isHolding", false);
        prev_pos = transform.position;
    }

    void FixedUpdate() {

        bool isMoving = false;
        float dir_x = Input.GetAxisRaw("Horizontal");
        float dir_z = Input.GetAxisRaw("Vertical");

        float move_direct = Mathf.Atan2(dir_z,dir_x);

        Vector3 target_velocity = new Vector3(speed * dir_x, 0, speed * dir_z);
        rb.velocity = target_velocity;
        
        if (Input.GetKeyDown(KeyCode.E)) {
            equip.equipping = true;
            anim.SetBool("isHolding",true);
        }



        
        
        /*
        if (Mathf.Abs(target_velocity.x) > Mathf.Abs(rb.velocity.x)) {
            rb.velocity = new Vector3(Mathf.Lerp(target_velocity.x, rb.velocity.x, Time.deltaTime), 0, Mathf.Lerp(target_velocity.z, rb.velocity.z, Time.deltaTime));
            
        }
        */




        float move_angle = Mathf.Atan2(transform.position.x-prev_pos.x,transform.position.z-prev_pos.z);
        transform.rotation = Quaternion.Euler(0, move_angle * Mathf.Rad2Deg, 0);

        if (dir_x != 0 || dir_z != 0) {
            prev_pos = transform.position;
            isMoving = true;
        }
        /*
        //rotate player based on movement direction
        if (dir_x != 0) {
            float move_angle = Mathf.Atan2(dir_x,transform.rotation.z);
            transform.rotation = Quaternion.Euler(0, move_angle * Mathf.Rad2Deg, 0);
        }
        if (dir_z != 0) {
            float move_angle = Mathf.Atan2(transform.rotation.x, dir_z);
            transform.rotation = Quaternion.Euler(0, move_angle * Mathf.Rad2Deg, 0);
        }
        */
        anim.SetBool("isMoving",isMoving);
    }
    
}
