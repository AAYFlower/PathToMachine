using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
     public float fireRate;
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
        CheckShoot();
    }
    void CheckShoot()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, firepoint.position,firepoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

}
