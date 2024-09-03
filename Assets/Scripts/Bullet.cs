using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //GameManager _gameManager;
    int _damage = 33;

    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(_damage);
            Destroy(gameObject);
        }

    }
}
