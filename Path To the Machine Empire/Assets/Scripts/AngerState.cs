using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerState : MonoBehaviour
{
    public GameObject fighttrigger;
	private enum AngerPhases
	{
		start,
		phase1,
		phase1trans,
		phase2
	};
	private AngerPhases currentPhase = AngerPhases.start;
    ChaseBehavior chase;
    FireBehavior fire;
    bool startfight;
    Enemy enemy;
    float currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponent<ChaseBehavior>();
        fire = GetComponent<FireBehavior>();
		enemy = GetComponent<Enemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        startfight = fighttrigger.GetComponent<FightTrigger>().startFight;
        currenthealth = enemy.health;

		switch(currentPhase)
		{
			case AngerPhases.start:
				if(startfight)
				{
					currentPhase = AngerPhases.phase1;
					fire.canShoot = true;
				}
				break;
			case AngerPhases.phase1:
				if (currenthealth <= 50f)
				{
					currentPhase = AngerPhases.phase1trans;
				}
				break;
			case AngerPhases.phase1trans:
				//just in case
				fire.canShoot = false;
				currentPhase = AngerPhases.phase2;
				break;
			case AngerPhases.phase2:
				if(!fire.canShoot)
				{
					fire.canShoot = true;
				}
				if (!chase.isFollowing)
				{
					chase.isFollowing = true;
				}
				break;
		}        
    }
}
