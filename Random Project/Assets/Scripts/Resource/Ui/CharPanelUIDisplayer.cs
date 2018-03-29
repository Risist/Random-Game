using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharPanelUIDisplayer : MonoBehaviour {



    ProgressionManager manager;
    EnergyController energyController;
    HealthController healthController;
    Text levelText;
    Text hpRegenText;
    Text enRegenText;
    public SkillSlot skillSlot;
    GameObject skillContent;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressionManager>();
        energyController = manager.GetComponent<EnergyController>();
        healthController = manager.GetComponent<HealthController>();
        Transform charStatsInfo = gameObject.transform.Find("CharacterStatsInfo");
        levelText = charStatsInfo.transform.Find("CharacterLevelValueText").GetComponent<Text>();
        hpRegenText = charStatsInfo.transform.Find("CharacterHPRegenValueText").GetComponent<Text>();
        enRegenText = charStatsInfo.transform.Find("CharacterEnergyRegenValueText").GetComponent<Text>();
        skillContent = GameObject.FindGameObjectWithTag("SkillBookContent");
    }


    // Use this for initialization
    void Start ()
    {
        // Instantiate skillslots in skill book for every skill player has
        foreach (var skill in manager.unlockedSkills)
        {
            var sSlot = Instantiate(skillSlot) as SkillSlot;
            sSlot.Skill = skill;
            sSlot.gameObject.SetActive(true);
            sSlot.SkillNameText.text = skill.displayName.ToString();
            sSlot.SkillIcon.sprite = skill.skillIcon;
            sSlot.SkillDescriptionText.text = skill.description.ToString();
            sSlot.SkillCostText.text = "EN: " + skill.cost.ToString();
            sSlot.gameObject.transform.SetParent(skillContent.transform, false);  
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        levelText.text = manager.lvl.ToString();
        hpRegenText.text = healthController.regeneration.ToString();
        enRegenText.text = energyController.regeneration.ToString();
    }
}
