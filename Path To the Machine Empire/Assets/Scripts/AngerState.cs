using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerState : MonoBehaviour
{
    public GameObject fighttrigger;
    bool phase1;
    bool phase2;
    ChaseBehavior chase;
    FireBehavior fire;
    bool startfight;
    Enemy health;
    float currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        phase1 = false;
        phase2 = false;
        chase = GetComponent<ChaseBehavior>();
        fire = GetComponent<FireBehavior>();
        health = GetComponent<Enemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        startfight = fighttrigger.GetComponent<FightTrigger>().startFight;
        currenthealth = health.health;

        Debug.Log(startfight);
        if (startfight == true)
        {
            phase1 = true;
        }

        if(phase1 == true)
        {
            fire.enabled = true;
        }

        if(phase2 == true)
        {
            chase.enabled = true;
        }

        if(currenthealth <= 50f)
        {
            phase2 = true;
        }
        
    }
}
