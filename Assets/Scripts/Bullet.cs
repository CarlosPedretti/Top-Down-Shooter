using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Enemy enemy;
    public PlayerConfig playerConfig;


    void Start()
    {
        playerConfig = FindObjectOfType<PlayerConfig>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(playerConfig.damage);

        }

        Destroy(gameObject);
    }

}
