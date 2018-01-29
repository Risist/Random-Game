using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SkillManager))]
public class LvlManager : MonoBehaviour {

	public int lvl;
	public float requiredXpBase;
	public float requiredXpScale;
	public float xp;
	public float GetRequiredXp() { return requiredXpBase + lvl * requiredXpScale; }

	public Image xpBar;
	public int leftUpgradePoints = 0;

	public void LvlUp()
	{
		++lvl;
		++leftUpgradePoints;
	}
	public void GainXp(float s)
	{
		xp += s;
		if (xp >= GetRequiredXp())
		{
			xp -= GetRequiredXp();
			LvlUp();
		}

		if (xpBar)
			xpBar.fillAmount = xp / GetRequiredXp();
	}

	// Use this for initialization
	void Start () {
	}
}
