using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCooldownUIDisplayer : MonoBehaviour {

    public bool updateProgress = true;
    public ProgressionManager manager;
    public int skillNum;
    WeaponBase skill;
    Image maskImage;
    public Image skillIcon;
    Text text;

    // Use this for initialization
    void Start ()
    {
        maskImage = GetComponentsInChildren<Image>()[1];
        text = GetComponentInChildren<Text>();
        skill = manager.slots[skillNum].skillObject;
        skillIcon = GetComponent<Image>();
        skillIcon.overrideSprite = manager.slots[skillNum].skillObject.skillIcon;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (updateProgress)
            if (skill.cd.isReady())
                SkillReady();
            else SkillCooldown();
    }

    private void SkillReady()
    {
        text.enabled = false;
        maskImage.enabled = false;
    }

    private void SkillCooldown()
    {
        if (text.enabled == false)
            text.enabled = true;
        if (maskImage.enabled == false)
            maskImage.enabled = true;

        float cdTimeLeft = skill.cd.actualTime + skill.cd.cd - Time.time;
        float roundedCooldown = Mathf.Round(cdTimeLeft);
        text.text = roundedCooldown.ToString();
        maskImage.fillAmount = (cdTimeLeft / skill.cd.cd);
    }
}
