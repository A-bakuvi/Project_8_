using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    bool keepChecking = true;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (keepChecking)
        {
            if (collision.gameObject.tag == "Bouncing" || collision.gameObject.tag == "Mbullets" || collision.gameObject.tag == "Shield")
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-33.0f, 30.0f), Random.Range(18.0f, -17.0f));
            }
            else
            {
                keepChecking = false;
            }
        }

    }
}
