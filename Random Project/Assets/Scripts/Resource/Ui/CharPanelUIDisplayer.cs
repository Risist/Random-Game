using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharPanelUIDisplayer : MonoBehaviour {



    public ProgressionManager manager;
    EnergyController energyController;
    HealthController healthController;
    public Text levelText;
    public Text hpRegenText;
    public Text enRegenText;
    public SkillSlot skillSlot;
    public GameObject skillContent;

    // Use this for initialization
    void Start ()
    {
        energyController = manager.GetComponent<EnergyController>();
        healthController = manager.GetComponent<HealthController>();

        // Instantiate skillslots in skill book for every skill player has
        foreach (var skill in manager.unlockedSkills)
        {
            var sSlot = Instantiate(skillSlot) as SkillSlot;
            sSlot.skill = skill;
            sSlot.gameObject.SetActive(true);
            sSlot.skillNameText.text = skill.displayName.ToString();
            sSlot.skillIcon.sprite = skill.skillIcon;
            sSlot.skillDescriptionText.text = skill.description.ToString();
            sSlot.skillCostText.text = "EN: " + skill.cost.ToString();

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
