using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerConfig : MonoBehaviour, IHealth
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 PlayerInput;
    float horizontalMov;
    float verticalMov;

    private Camera mainCam;
    private Vector3 mousePos;

    public int maxHealth = 100;
    public int currentHealth;
    public int damage;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        currentHealth = maxHealth;
    }

    void Update()
    {

        horizontalMov = Input.GetAxisRaw("Horizontal");
        verticalMov = Input.GetAxisRaw("Vertical");
        PlayerInput = new Vector2(horizontalMov, verticalMov).normalized;


        LookAtMouse();
    }


    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * moveSpeed;
        rb.velocity = moveForce;

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

    void OnCollisionEnter2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Enemy")
        {
            
        }
    }


    public void Heal(int health)
    {

        currentHealth += health;

    }

    private void Die()
    {

        GameManager.Instance.ShowGameOver();
    }


    private void LookAtMouse()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }
}

