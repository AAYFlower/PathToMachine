using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    public GameObject bullet;
	public bool canShoot = false;
    public Transform firepoint;
     public float fireRate;
	public int damage = 2;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        //fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if(canShoot)
		{
			CheckShoot();
		}
	}
    void CheckShoot()
    {
        if(Time.time > nextFire)
        {
            GameObject firedBullet = Instantiate(bullet, firepoint.position,firepoint.rotation);
			EnemyBullet newBullet = firedBullet.GetComponent<EnemyBullet>();
			if(newBullet != null)
			{
				newBullet.damage = damage;
			}
            nextFire = Time.time + fireRate;
        }
    }

}
