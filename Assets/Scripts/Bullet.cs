using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerConfig playerConfig;

    private void Start()
    {
        playerConfig = FindObjectOfType<PlayerConfig>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerConfig.damage);
            }
        }

        Destroy(gameObject);
    }
}



