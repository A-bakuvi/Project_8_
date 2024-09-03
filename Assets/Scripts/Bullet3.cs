using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    int _damage = 20;

    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Wait2());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(_damage);
            Destroy(gameObject);
        }

    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
