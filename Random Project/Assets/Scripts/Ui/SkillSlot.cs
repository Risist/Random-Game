using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillSlot : MonoBehaviour 
{
    WeaponBase skill;
    Button button;
	Text skillNameText;
	Text skillCostText;
	Text skillDescriptionText;
	Image skillIcon;

    public void Awake()
    {
        SkillNameText = gameObject.transform.Find("SkillNameText").GetComponent<Text>();
        SkillCostText = gameObject.transform.Find("SkillCostText").GetComponent<Text>();
        SkillDescriptionText = gameObject.transform.Find("SkillDescriptionText").GetComponent<Text>();
        SkillIcon = gameObject.transform.Find("SkillIconImage").GetComponent<Image>();
    }

    public WeaponBase Skill { get { return skill; } set { skill = value; } }
    public Button Button { get { return button; } set { button = value; } }
    public Text SkillNameText { get { return skillNameText; } set { skillNameText = value; } }
    public Text SkillCostText { get { return skillCostText; } set { skillCostText = value; } }
    public Text SkillDescriptionText { get { return skillDescriptionText; } set { skillDescriptionText = value; } }
    public Image SkillIcon { get { return skillIcon; } set { skillIcon = value; } }
}
