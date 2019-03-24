using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    //public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
        if (hitInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
