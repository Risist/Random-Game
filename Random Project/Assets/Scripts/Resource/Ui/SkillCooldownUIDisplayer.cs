using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCooldownUIDisplayer : MonoBehaviour {

    public bool updateProgress = true;
    public ProgressionManager manager;
    public int skillNum;
    public WeaponBase skill;
    public Image skillPanelMaskImage;
    public Image skillPanelIcon;
    public Image charPanelMaskImage;
    public Image charPanelIcon;
    Text text;

    // Use this for initialization
    void Start ()
    {
        text = GetComponentInChildren<Text>();
        skill = manager.slots[skillNum].skillObject;
        skillPanelMaskImage = GetComponentsInChildren<Image>()[1];
        if (skill)
        {
            //skill = manager.unlockedSkills[skillNum];
            skillPanelIcon = GetComponent<Image>();
            skillPanelIcon.overrideSprite = manager.slots[skillNum].skillObject.skillIcon;
            //skillPanelIcon.overrideSprite = skill.skillIcon;
            //charPanelIcon.overrideSprite = skill.skillIcon;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (updateProgress && skill)
            if ( skill.cd.isReady())
                SkillReady();
            else SkillCooldown();
    }

    private void SkillReady()
    {
        text.enabled = false;
        skillPanelMaskImage.enabled = false;
        //skillPanelMaskImage.enabled = false;
    }

    private void SkillCooldown()
    {
        if (text.enabled == false)
            text.enabled = true;
        if (skillPanelMaskImage.enabled == false)
            skillPanelMaskImage.enabled = true;
        //if (skillPanelMaskImage.enabled == false)
        //    skillPanelMaskImage.enabled = true;

        float cdTimeLeft = skill.cd.actualTime + skill.cd.cd - Time.time;
        float roundedCooldown = Mathf.Round(cdTimeLeft);
        text.text = roundedCooldown.ToString();
        //skillPanelMaskImage.fillAmount = (cdTimeLeft / skill.cd.cd);
        skillPanelMaskImage.fillAmount = (cdTimeLeft / skill.cd.cd);
    }
}
