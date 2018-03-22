using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodShade : MonoBehaviour {

	public float shadeCdMin = 0.0f;
	public float shadeCdMax = 1.0f;

	public float shadeLenghtMin = 0.0f;
	public float shadeLenghtMax = 1.0f;

	[Range(0.0f, 1.0f)]
	public float normalColorA;
	[Range(0.0f, 1.0f)]
	public float shadeColorA;

	[Range(0.0f, 1.0f)]
	public float shadeVisibility = 1.0f;

	Timer shadeCd = new Timer();
	bool atShade = false;

	void SetShade(bool _atShade)
	{
		atShade = _atShade;
		if(atShade)
		{
			foreach(var it in renderers)
				it.color = new Color(it.color.r, it.color.g, it.color.b, shadeColorA);
			unit.distanceModificator = shadeVisibility;

			shadeCd.cd = Random.Range(shadeLenghtMin, shadeLenghtMax);
			shadeCd.restart();
			//Debug.Log("atShade");
		}
		else
		{
			foreach (var it in renderers)
				it.color = new Color(it.color.r, it.color.g, it.color.b, normalColorA);
			unit.distanceModificator = 1.0f;

			shadeCd.cd = Random.Range(shadeCdMin, shadeCdMax);
			shadeCd.restart();

			//Debug.Log("atNormal");
		}
	}

	SpriteRenderer[] renderers;
	AiPerceiveUnit unit;

	public void Start()
	{
		renderers = GetComponentsInChildren<SpriteRenderer>();
		unit = GetComponentInParent<AiPerceiveUnit>();
	}

	public void Update()
	{
		if(shadeCd.isReady())
			SetShade(!atShade);
	}

}
