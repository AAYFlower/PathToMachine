using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : MonoBehaviour
{
	// Start is called before the first frame update
	public bool isFollowing = false;
    public float speed;
    private Transform target;
    public int damage;
    public float knockback;
    Rigidbody2D playerrb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(isFollowing)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        
    }
}
