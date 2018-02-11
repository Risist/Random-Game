using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for representing relations between agents
 * TODO move to ScriptableObject instead of MonoBehaviour
 */
public class AiFraction : MonoBehaviour
{
	public enum Attitude
	{
		friendly,
		neutral,
		enemy
	}
	public string fractionName;
	public string[] friendlyFractions;
	public string[] enemyFractions;

	public Attitude GetAttitude(string fraction)
	{
		if (fraction == fractionName)
			return Attitude.friendly;

		foreach (var it in friendlyFractions)
			if (it == fraction)
				return Attitude.friendly;

		foreach (var it in enemyFractions)
			if (it == fraction)
				return Attitude.enemy;

		return Attitude.neutral;
	}
}
