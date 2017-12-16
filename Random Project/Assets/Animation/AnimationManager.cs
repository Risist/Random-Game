using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	bool isCasting = false;
	public void CastAnimation() { isCasting = true; }

	public Animator animator;
	public string animStartCode = "isCasting";
	int animHash;

	private void Start()
	{
		animHash = Animator.StringToHash(animStartCode);
		if (!animator)
			animator = GetComponent<Animator>();
	}

	public void LateUpdate()
	{
		animator.SetBool(animHash, isCasting);
		isCasting = false;
	}
}
