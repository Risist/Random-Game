using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	/*[System.Serializable]
	public class SkillSlot
	{
		public string keyCode;
		public GameObject skillObject;


		public bool isActivated() { return skillObject.activeInHierarchy; }
	}*/

	//public SkillSlot[] slots;
	[System.Serializable]
	public class SkillData
	{
		public string shortKey;
		public GameObject skillObject;
	}
	public SkillData[] skills;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach( var it in skills)
			if(Input.GetKeyDown(it.shortKey) )
			{
				foreach (var itt in skills)
					itt.skillObject.SetActive(false);
				it.skillObject.SetActive(true);
				break;
			}
	}
}
