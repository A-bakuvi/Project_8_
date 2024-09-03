using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _health = 99f;
    float _currentHealth;

    void Start()
    {
        _currentHealth = _health;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageEnemy(int damage)
    {
        _currentHealth -= damage;
    }
}
