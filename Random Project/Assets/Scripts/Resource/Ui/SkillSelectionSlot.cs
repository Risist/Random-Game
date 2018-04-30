using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillSelectionSlot : MonoBehaviour
{
    //WeaponBase skill;
    //Text skillName;
    //Text level;
    //Text cost;
    //Text description;
    //Image icon;

    public WeaponBase Skill { get; set; }
    public Text Name { get; set; }
    public Text Level { get; set; }
    public Text Cost { get; set; }
    public Text Description { get; set; }
    public Image Icon { get; set; }


    private void Awake()
    {
        Name = gameObject.transform.Find("Background").Find("SkillNameText").GetComponent<Text>();
        Level = gameObject.transform.Find("Background").Find("SkillLvlText").GetComponent<Text>();
        Cost = gameObject.transform.Find("Background").Find("SkillCostText").GetComponent<Text>();
        Description = gameObject.transform.Find("Background").Find("SkillDescriptionText").GetComponent<Text>();
        Icon = gameObject.transform.Find("Background").Find("SkillIconImage").GetComponent<Image>();
    }

    //public WeaponBase Skill { get { return skill; } set { skill = value; } }
    //public Text Name { get { return skillName; } set { skillName = value; } }
    //public Text Level { get { return level; } set { level = value; } }
    //public Text Cost { get { return cost; } set { cost = value; } }
    //public Text Description { get { return description; } set { description = value; } }
    //public Image Icon { get { return icon; } set { icon = value; } }
}
