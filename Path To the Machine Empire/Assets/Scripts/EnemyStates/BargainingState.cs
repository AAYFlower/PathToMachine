using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainingState : MonoBehaviour
{
	public GameObject fighttrigger;


	private enum BargainPhases
	{
		start,
		phase1,
		phase1trans,
		phase2,
		phase2trans,
		phase3
	};
	[SerializeField]
	private BargainPhases currentPhase = BargainPhases.start;
	private ChaseBehavior chase;
	private FireBehavior fire;
	private bool startfight;
	private Enemy enemy;
	private float currenthealth;
	private int startHealth = 0;

	void Start()
    {
		chase = GetComponent<ChaseBehavior>();
		fire = GetComponent<FireBehavior>();
		enemy = GetComponent<Enemy>();
	}

    void Update()
    {
		startfight = fighttrigger.GetComponent<FightTrigger>().startFight;
		currenthealth = enemy.health;
		switch (currentPhase)
		{
			case BargainPhases.start:
				break;

		}
	}
}
