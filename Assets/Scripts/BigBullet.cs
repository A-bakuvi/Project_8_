using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    int _damage = 99;

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
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
