using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTrigger : MonoBehaviour {

    public Timer inactiveTime;
    public string idleCode;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inactiveTime.isReadyRestart())
        {
            animator.SetTrigger(idleCode);
        }
	}
}
