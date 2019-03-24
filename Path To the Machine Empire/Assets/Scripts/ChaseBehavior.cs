using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : MonoBehaviour
{
	// Start is called before the first frame update
	public bool isFollowing = false;
	public bool isJumping = false;
	public float jumpRate = 1f;
	public float jumpPower = 30f;
    public float speed;
    private Transform target;
    public int damage;
    public float knockback;
    Rigidbody2D playerrb;
	Rigidbody2D rb2d;
	[SerializeField]
	private bool grounded = true;
	private float nextJump;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		nextJump = Time.time;
		rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(isFollowing)
		{
			//jump stuff
			Vector2 jumpVector = new Vector2(0, 0);
			if (isJumping && grounded && Time.time > nextJump)
			{
				//do a jump
				jumpVector = Vector2.up * 5;
				rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
				//rb2d.AddForce(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime), ForceMode2D.Impulse);
				Vector2 direction = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				direction = direction / direction.magnitude;

				rb2d.velocity = new Vector2(-direction.x * jumpPower, rb2d.velocity.y);
				nextJump += jumpRate;
			}
			else
			{
				if (grounded)
				{
					transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				}
				else
				{

				}
			}
			
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

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			grounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			grounded = false;
		}
	}
}
