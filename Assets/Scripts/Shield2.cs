using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield2 : MonoBehaviour
{
    public GameObject player1; // Reference to the player object
    public float rotationSpeed1 = 100f;

    void Update()
    {
        // Make the shield follow the player's position
        transform.position = player1.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy2")
        {
            Destroy(collider.gameObject);
        }
    }
}
