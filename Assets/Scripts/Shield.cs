using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float rotationSpeed = 100f;

    void Update()
    {
        // Make the shield follow the player's position
        transform.position = player.transform.position;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.tag == "Bullet2")
        {
            Destroy(collider.gameObject);
        }
    }
}
