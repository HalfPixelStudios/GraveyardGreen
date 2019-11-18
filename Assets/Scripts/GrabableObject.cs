using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour {

    public bool two_hand_hold;

    public Vector3 position_offset;
    public Quaternion rotation_offset;
    public GameObject owner;

    private Vector3 start_pos;
    
    void Start() {
        start_pos = transform.position;
    }

    void Update() {
        /* used for testing orientation
        if (owner != null) {
            transform.localPosition = position_offset;
            transform.localRotation = rotation_offset;
        }
        */
    }

    public void reset_y_position() {
        transform.position = new Vector3(transform.position.x,start_pos.y,transform.position.z);
    }
}
