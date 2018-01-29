using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeMenu : MonoBehaviour {

	public Text leftSkillPoints;
	public Text[] names;
	public Text[] descriptions;
	public Button[] buttons;
	public GameObject menuObj;

	public void initButtons(UpgradeField field)
	{
		buttons[0].onClick.AddListener(field.buttonUnlockSkill_0);
		buttons[1].onClick.AddListener(field.buttonUnlockSkill_1);
		buttons[2].onClick.AddListener(field.buttonUnlockSkill_2);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
