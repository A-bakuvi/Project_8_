using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    int _damage = 33;
    //int _damage99 = 99;
    //bool _isShield = false;
    //
    //bool _isBigBullet = false;
    //[SerializeField] GameObject _shield;
    [SerializeField] GameObject _bigBullet;


    void Start()
    {
        //_shield = GameObject.Find("Player1 2").GetComponent<GameObject Shield >();
        //_shield = GameObject.FindGameObjectWithTag("Shield");
        //_shield = GameObject.Find("Shield");

    }

    void Update()
    {
        /*if (!_isShield)
        {
            _shield.SetActive(true);
        }
        if (!_isBigBullet)
        {
            _bigBullet.SetActive(true);
        }*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            /*if (!_isShield)
            {
                Destroy(gameObject);
                StartCoroutine(Wait10());
            }
            else if (!_isBigBullet)
            {
                collision.gameObject.GetComponent<Enemy2Health>().DamageEnemy3(_damage99);
                Destroy(gameObject);
            }*/
            //else
            //{
                collision.gameObject.GetComponent<Enemy2Health>().DamageEnemy2(_damage);
                Destroy(gameObject);
            //}
        }

    }

    /*IEnumerator Wait10()
    {
        yield return new WaitForSeconds(10);
        _isShield = false;
    }*/
}
