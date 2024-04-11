using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
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
        Debug.Log("Found parent: " + ps);
        initial = ps.initial;
        Debug.Log("Initial transform: " + initial.position + ", " + initial.rotation);
        transform.parent = null;

        transform.position = initial.position;
        transform.rotation = initial.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // (update) move projectile, check distance from initial position, despawn if collision or too far
        transform.Translate(transform.forward*Time.deltaTime*speed);

        float dist = Vector3.Distance(transform.position, initial.position);
        Debug.Log("Projectil distance: " + dist);

        if (dist > range) {
            Destroy(gameObject);
        }
    }
}
