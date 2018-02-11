using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dunnoMind : MonoBehaviour {
	

	[System.Serializable]
	public class BehaviourData
	{
		public float chance;
		[System.NonSerialized]
		public int idAnim;
		public string animKeyName;

		public void initAnimId()
		{
			idAnim = Animator.StringToHash(animKeyName);
		}

		public float cdChangeAnimMin = 1.0f;
		public float cdChangeAnimMax = 5.0f;
	}

	// varriables to index animations
	public Animator animator;
	public BehaviourData[] behaviours;
	// random data
	public Timer cdChangeBehavour = new Timer();

	// Use this for initialization
	void Start () {
	
		if(!animator)
			animator = GetComponent<Animator>();

		foreach (var it in behaviours)
			it.initAnimId();
	}
	
	// Update is called once per frame
	void Update () {
		if (cdChangeBehavour.isReadyRestart())
		{
			float[] chances = new float[behaviours.Length];
			for( int i = 0; i < chances.Length; ++i)
			{
				chances[i] = behaviours[i].chance;
			}

			RandomChance chancesOfBehaviours = new RandomChance();
			chancesOfBehaviours.chances = chances;
			int id = chancesOfBehaviours.GetRandedId();
			animator.SetTrigger(behaviours[id].idAnim);

			cdChangeBehavour.cd = Random.Range(behaviours[id].cdChangeAnimMin, behaviours[id].cdChangeAnimMax);
		}
	}
}
