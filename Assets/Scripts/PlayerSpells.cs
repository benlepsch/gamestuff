using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerSpells : NetworkBehaviour
{
    [SerializeField] Transform projectilePrefab;

    public Transform initial;

    // Update is called once per frame
    void Update()
    {
        /* -------------------------- casting spells ---------------------------- */

        // left control or mouse left click
        if (Input.GetButtonDown("Fire1")) {
            // Debug.Log("casting spell or soemthing");

            Transform pp = Instantiate(projectilePrefab);
            pp.GetComponent<NetworkObject>().Spawn(true);
            pp.parent = transform;

            Debug.Log("Spawnd projectile at " + pp.position);
            Debug.Log("Parent (player) at " + transform.position);

            //initial = transform.parent.position;

            // ---- player script ----
            // set global variables to save value of inital position + direction (player rotation)
            // spawn projectile as child of player
            
            // ---- projectile script ----
            // (start) find and save initial position + direction values
            // (update) move projectile, check distance from initial position, despawn if collision or too far
        }
    }
}
