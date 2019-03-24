using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenialState : MonoBehaviour
{
	public GameObject fighttrigger;
	public float slowWalk = 10f;
	public float slowFireRate = 2.5f;
	public int slowDamage = 2;
	public float fastWalk = 100f;
	public float fastFireRate = 0.3f;
	public int fastDamage = 5;
	public float phase1DoneHealth = 0.5f;

	public GameObject slowBullet;
	public GameObject fastBullet;

	private enum DenialPhases
	{
		start,
		phase1,
		phase1trans,
		phase2
	};
	[SerializeField]
	private DenialPhases currentPhase = DenialPhases.start;
	private ChaseBehavior chase;
	private FireBehavior fire;
	private bool startfight;
	private Enemy enemy;
	private float currenthealth;
	private int startHealth = 0;

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

		switch (currentPhase)
		{
			case DenialPhases.start:
				if(startfight)
				{
					startHealth = enemy.health;
					fire.canShoot = false;
					chase.isFollowing = false;
					if (startfight)
					{
						currentPhase = DenialPhases.phase1;
						fire.canShoot = true;
						fire.fireRate = slowFireRate;
						fire.damage = slowDamage;
						fire.bullet = slowBullet;
						chase.isFollowing = true;
						chase.speed = slowWalk;
					}
				}
				break;
			case DenialPhases.phase1:
				if(currenthealth <= startHealth * phase1DoneHealth)
				{
					currentPhase = DenialPhases.phase1trans;
				}
				break;
			case DenialPhases.phase1trans:
				currentPhase = DenialPhases.phase2;
				chase.isFollowing = true;
				chase.speed = fastWalk;
				chase.isJumping = true;
				fire.canShoot = true;
				fire.fireRate = fastFireRate;
				fire.damage = fastDamage;
				fire.bullet = fastBullet;
				break;
			case DenialPhases.phase2:
				break;
		}
	}
}
