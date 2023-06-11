using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, IHealth
{

    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int maxHealth = 100;
    public int currentHealth;
    public int damage;



    private PlayerConfig playerConfig;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }


    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
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
