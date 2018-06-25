using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillSelectionSlot : MonoBehaviour
{

    public WeaponBase skill;
    public Text skillName;
    public Text level;
    public Text cost;
    public Text description;
    public Image icon;


    private void Awake()
    {
        skillName = gameObject.transform.Find("Background").Find("SkillNameText").GetComponent<Text>();
        level = gameObject.transform.Find("Background").Find("SkillLvlText").GetComponent<Text>();
        cost = gameObject.transform.Find("Background").Find("SkillCostText").GetComponent<Text>();
        description = gameObject.transform.Find("Background").Find("SkillDescriptionText").GetComponent<Text>();
        icon = gameObject.transform.Find("Background").Find("SkillIconImage").GetComponent<Image>();
    }
}
