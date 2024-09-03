using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public float _health2 = 99f;
    float _currentHealth;

    void Start()
    {
        _currentHealth = _health2;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageEnemy2(int damage2)
    {
        _currentHealth -= damage2;
    }
}
