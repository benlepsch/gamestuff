using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ProjectileMovement : NetworkBehaviour
{

    private Transform initial;

    private float speed = 25;
    private float range = 100;

    // Start is called before the first frame update
    void Start()
    {
        // ---- projectile script ----
        // (start) find and save initial position + direction values
        PlayerSpells ps = (PlayerSpells) GameObject.Find(transform.parent.name).GetComponent("PlayerSpells");
        MouseMovement mm = (MouseMovement) GameObject.Find(transform.parent.name).GetComponent("MouseMovement");

        // Debug.Log("Found parent: " + ps);
        initial = ps.initial;
        float xRot = mm.xRotation;
        float yRot = mm.yRotation;
        // Debug.Log("Initial transform: " + initial.position + ", " + initial.rotation);
        // Debug.Log("Initial Rotation: " + initial.rotation);
        transform.parent = null;

        transform.position = initial.position;
        transform.localRotation = Quaternion.Euler(xRot, yRot/2, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // (update) move projectile, check distance from initial position, despawn if collision or too far
        transform.Translate(transform.forward*Time.deltaTime*speed);

        float dist = Vector3.Distance(transform.position, initial.position);
        if (dist > range) {
            Destroy(gameObject);
        }
        // Debug.Log("Projectil distance: " + dist);
    }
}
