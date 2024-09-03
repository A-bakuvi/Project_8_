using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;  // Reference to the player's position
    Transform player1;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float detectionRange = 10f;  // Range within which the enemy accelerates
    public float normalSpeed = 3.5f;  // Normal speed of the enemy
    public float chaseSpeed = 7f;  // Speed when chasing the player
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        player = GameObject.FindGameObjectWithTag("Enemy").transform;
        player1 = GameObject.FindGameObjectWithTag("Enemy1").transform;

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = normalSpeed;
    }

    void Update()
    {
        Transform closestPlayer = FindClosestPlayer();
        navMeshAgent.SetDestination(closestPlayer.position);
        float distanceToPlayer = Vector3.Distance(transform.position, closestPlayer.position);

        Vector3 direction = closestPlayer.position - transform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Calculate the angle between the enemy's current forward direction and the target direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        // The '-90' adjusts the angle so that the enemy's "up" direction points towards the target.

        if (distanceToPlayer <= detectionRange)
        {
            navMeshAgent.speed = chaseSpeed;
        }
        else
        {
            navMeshAgent.speed = normalSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            gameManager.GameOver();
            //Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Enemy1"))
        {
            collision.gameObject.SetActive(false);
            gameManager.GameOver();
            //Time.timeScale = 0;
        }

    }
    Transform FindClosestPlayer()
    {
        float distanceToPlayer1 = Vector3.Distance(transform.position, player.position);
        float distanceToPlayer2 = Vector3.Distance(transform.position, player1.position);

        // Return the closest player
        if (distanceToPlayer1 < distanceToPlayer2)
        {
            return player;
        }
        else
        {
            return player1;
        }
    }

}
