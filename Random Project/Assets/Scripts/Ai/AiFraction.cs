using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for representing relations between agents
 * TODO move to ScriptableObject instead of MonoBehaviour
 * TODO ints instead of strings
 */
public class AiFraction : MonoBehaviour
{
	public enum Attitude
	{
		friendly,
		neutral,
		enemy,
		none
	}
	public string fractionName;
	public string[] friendlyFractions;
	public string[] enemyFractions;

	public Attitude GetAttitude(string fraction)
	{
		if (fraction.Equals(fractionName))
			return Attitude.friendly;

		foreach (var it in friendlyFractions)
			if (it.Equals(fraction))
				return Attitude.friendly;

		foreach (var it in enemyFractions)
			if (it.Equals(fraction))
				return Attitude.enemy;

		return Attitude.neutral;
	}
}
