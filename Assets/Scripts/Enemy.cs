using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, IHealth
{

    [SerializeField] private Transform objective;

    private NavMeshAgent navMeshAgent;

    public int maxHealth = 100;
    public int currentHealth;
    public int damage;

    private PlayerConfig player;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

        currentHealth = maxHealth;
    }


    void FixedUpdate()
    {
        navMeshAgent.SetDestination(objective.position);
    }


    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IHealth player = collision.gameObject.GetComponent<IHealth>();

            if (player != null)
            {
                player.TakeDamage(damage); 
            }
        }
    }



    public void Heal(int health)
    {

        currentHealth += health;

    }

    private void Die()
    {
        Destroy(gameObject);
    }


}
