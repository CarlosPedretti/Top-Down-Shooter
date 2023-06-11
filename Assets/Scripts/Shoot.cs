using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform bulletPoint;
    public Transform flashPoint;
    public GameObject bulletPrefab;
    public GameObject shotLightPrefab;

    public float bulletForce = 20f;
    public float shotLightDuration = 1;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           Shot();
        }
    }

     void Shot()
     {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        GameObject shotLight = Instantiate(shotLightPrefab, flashPoint.position, flashPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletPoint.up * bulletForce, ForceMode2D.Impulse);


        Destroy(shotLight, shotLightDuration);
     }
}
