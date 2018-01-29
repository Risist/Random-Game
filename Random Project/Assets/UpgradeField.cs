using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeField : MonoBehaviour {

	public GameObject upgradeUi;
	public Text lefSkillPointsTxt;
	string leftSkillPoints__;
	int lastLevel = 0;

	LvlManager lvlManager;
	SkillManager skillManager;

	[System.Serializable]
	public class SkillButtonUnlock
	{
		public int skillId;
		public Text name;
		public Text description;

		public void randId(SkillManager skillManager)
		{
			int n = 50;
			while (--n > 0)
			{
				var id = Random.Range(0, skillManager.possibleSkills.Length);
				if (!skillManager.isUnlocked(id))
				{
					skillId = id;
					name.text = skillManager.possibleSkills[id].GetComponent<WeaponBase>().displayName;
					description.text = skillManager.possibleSkills[id].GetComponent<WeaponBase>().description;
					break;
				}
			}
		}
	}

	public SkillButtonUnlock[] button;

	// Use this for initialization
	void Start () {
		lvlManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LvlManager>();
		skillManager = lvlManager.GetComponent<SkillManager>();

		var upgrademenu = GameObject.FindGameObjectWithTag("upgradeMenu").GetComponent<upgradeMenu>();
		upgradeUi = upgrademenu.menuObj;
		upgrademenu.initButtons(this);
		lefSkillPointsTxt = upgrademenu.leftSkillPoints;
		
		for(int i = 0; i < button.Length; ++i)
		{
			button[i].name = upgrademenu.names[i];
			button[i].description = upgrademenu.descriptions[i];
		}


		leftSkillPoints__ = lefSkillPointsTxt.text;
		lefSkillPointsTxt.text += lvlManager.leftUpgradePoints;

		foreach(var it in button)
			it.randId(skillManager);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			if(lvlManager.lvl != lastLevel )
			{
				foreach (var it in button)
					it.randId(skillManager);
			}
			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;
			upgradeUi.SetActive( true );
			skillManager.freezeSkills(false);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			upgradeUi.SetActive(false);
			skillManager.freezeSkills(true);
		}
	}


	public void buttonUnlockSkill()
	{
		if (lvlManager.leftUpgradePoints > 0)
		{
			skillManager.UnlockRandomSkill();
			--lvlManager.leftUpgradePoints;

			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;
		}
	}

	public void buttonUnlockSkill_0()
	{
		if (lvlManager.leftUpgradePoints > 0)
		{
			skillManager.unlockSkill(button[0].skillId);
			--lvlManager.leftUpgradePoints;

			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;

			foreach (var it in button)
				it.randId(skillManager);
		}
	}
	public void buttonUnlockSkill_1()
	{
		if (lvlManager.leftUpgradePoints > 0)
		{
			skillManager.unlockSkill(button[1].skillId);
			--lvlManager.leftUpgradePoints;

			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;

			foreach (var it in button)
				it.randId(skillManager);
		}
	}
	public void buttonUnlockSkill_2()
	{
		if (lvlManager.leftUpgradePoints > 0)
		{
			skillManager.unlockSkill(button[2].skillId);
			--lvlManager.leftUpgradePoints;

			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;

			foreach (var it in button)
				it.randId(skillManager);
		}
	}
	public void buttonUnlockSkill_3()
	{
		if (lvlManager.leftUpgradePoints > 0)
		{
			skillManager.unlockSkill(button[3].skillId);
			--lvlManager.leftUpgradePoints;

			lefSkillPointsTxt.text = leftSkillPoints__ + lvlManager.leftUpgradePoints;

			foreach (var it in button)
				it.randId(skillManager);
		}
	}

}
