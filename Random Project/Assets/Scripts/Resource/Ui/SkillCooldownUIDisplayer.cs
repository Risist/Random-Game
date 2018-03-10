using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCooldownUIDisplayer : MonoBehaviour {

    public bool updateProgress = true;
    public ProgressionManager manager;
    public int skillNum;
    WeaponBase skill;
    Image image;
    Text text;

    // Use this for initialization
    void Start ()
    {
        image = GetComponentsInChildren<Image>()[1];
        text = GetComponentInChildren<Text>();
        skill = manager.slots[skillNum].skillObject;
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
        image.enabled = false;
    }

    private void SkillCooldown()
    {
        if (text.enabled == false)
            text.enabled = true;
        if (image.enabled == false)
            image.enabled = true;

        float cdTimeLeft = skill.cd.actualTime + skill.cd.cd - Time.time;
        float roundedCooldown = Mathf.Round(cdTimeLeft);
        text.text = roundedCooldown.ToString();
        image.fillAmount = (cdTimeLeft / skill.cd.cd);
    }
}
