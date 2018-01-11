using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	[System.Serializable]
	public class SkillSlot
	{
		public string keyCode;
		public GameObject skillObject;
	}

	public SkillSlot[] slots;
	public List<GameObject> unlockedSkills;
	public GameObject[] possibleSkills;

	public int nInitialSkillMin = 1;
	public int nInitialSkillMax = 1;


	// Use this for initialization
	void Start () {
		int n = Random.Range(nInitialSkillMin, nInitialSkillMax);

		for (int i = 0; i < n; ++i)
			unlockSkill(Random.Range(0, possibleSkills.Length));



		foreach (var itSlot in slots)
			if (itSlot.skillObject)
			{
				var w = itSlot.skillObject.GetComponent<WeaponBase>();
				if (w)
					w.buttonCode = itSlot.keyCode;
				itSlot.skillObject.SetActive(true);
			}
	}

	public bool unlockSkill(int id)
	{
		// check if already unlocked
		foreach(var it in unlockedSkills)
			if( it.Equals(possibleSkills[id]))
			{
				return false;
			}

		unlockedSkills.Add(possibleSkills[id]);
		foreach (var itSlot in slots)
		{
			if(itSlot.skillObject == null)
			{
				itSlot.skillObject = possibleSkills[id];
				var w = itSlot.skillObject.GetComponent<WeaponBase>();
				if (w)
					w.buttonCode = itSlot.keyCode;

				itSlot.skillObject.SetActive(true);
				return true;
			}
		}

		return true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool b = false;
		int i = 0; 
		foreach(var it in unlockedSkills)
		{
			++i;
			if( Input.GetKey("" + i) )
			{
				foreach(var itSlot in slots)
				{
					if(Input.GetButton(itSlot.keyCode))
					{
						itSlot.skillObject = it;
						var w = it.GetComponent<WeaponBase>();
						if (w)
							w.buttonCode = itSlot.keyCode;
						b = true;
					}
				}
			}
		}

		if (b)
		{
			foreach (var it in unlockedSkills)
				it.SetActive(false);
			foreach (var itSlot in slots)
				if(itSlot.skillObject)
					itSlot.skillObject.SetActive(true);
		}
	}
}
