using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dunnoMind : MonoBehaviour {
	

	// varriables to index animations
	private int[] idAnim = new int[4];
	public Animator animator;

	// random data
	public RandomChance chancesOfBehaviours;
	public float cdChangeBehaviourMin = 1.0f;
	public float cdChangeBehaviourMax = 5.0f;
	Timer cdChangeBehavour = new Timer();

	// Use this for initialization
	void Start () {
		idAnim[0] = Animator.StringToHash("jump");
		idAnim[1] = Animator.StringToHash("jumpFast");
		idAnim[2] = Animator.StringToHash("swing");
		idAnim[3] = Animator.StringToHash("crush");

		if(!animator)
			animator = GetComponent<Animator>();

		cdChangeBehavour.cd = Random.Range(cdChangeBehaviourMin, cdChangeBehaviourMax);
	}
	
	// Update is called once per frame
	void Update () {
		if (cdChangeBehavour.isReadyRestart())
		{
			int id = chancesOfBehaviours.GetRandedId();
			animator.SetTrigger(idAnim[id]);

			cdChangeBehavour.cd = Random.Range(cdChangeBehaviourMin, cdChangeBehaviourMax);
		}
	}
}
