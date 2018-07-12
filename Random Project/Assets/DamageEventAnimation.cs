using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventAnimation : MonoBehaviour {

    public string[] animationCode;
    public float[] chances;
    public Timer cd;
    int[] animationCodeCasched;
    Animator animator;
    RandomChance randomChance = new RandomChance();

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        animationCodeCasched = new int[animationCode.Length];
        for(int i = 0; i < animationCode.Length; ++i)
            animationCodeCasched[i] = Animator.StringToHash(animationCode[i]);
        randomChance.chances = chances;
	}

    public void OnReceiveDamage(HealthController.DamageData data)
    {
        if(cd.isReadyRestart())
        {
            animator.SetTrigger(animationCodeCasched[randomChance.GetRandedId()]);
        }
    }
}
