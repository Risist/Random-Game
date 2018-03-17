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
        foreach (var skill in manager.slots)
        {
            var sSlot = Instantiate(skillSlot) as SkillSlot;
            sSlot.gameObject.SetActive(true);
            sSlot.skillNameText.text = skill.skillObject.displayName.ToString();
            sSlot.skillIcon.overrideSprite = skill.skillObject.skillIcon;
            sSlot.skillDescriptionText.text = skill.skillObject.description.ToString();
            sSlot.skillCostText.text = "EN: " + skill.skillObject.cost.ToString();

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
