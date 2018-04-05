using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SkillCooldownUIDisplayer : MonoBehaviour {

    public bool updateProgress = true;
    public int skillNum;

    SkillButton button;
    SkillButton assignmentButton;

    // Use this for initialization
    void Start ()
    {
        button = gameObject.GetComponent<SkillButton>();
        assignmentButton = GameObject.Find("SkillAssignmentPanel").GetComponent<SkillPanel>().skillButtons[skillNum];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (updateProgress && button.skill)
            if (button.skill.cd.isReady())
                SkillReady();
            else SkillCooldown();
    }

    private void SkillReady()
    {
        button.mask.enabled = false;
        button.cooldownText.enabled = false;
        assignmentButton.mask.enabled = false;
        assignmentButton.cooldownText.enabled = false;
    }

    private void SkillCooldown()
    {

        button.mask.enabled = true;
        button.cooldownText.enabled = true;
        assignmentButton.mask.enabled = true;
        assignmentButton.cooldownText.enabled = true;

        float cdTimeLeft = button.skill.cd.actualTime + button.skill.cd.cd - Time.time;
        float roundedCooldown = (float)Math.Round(cdTimeLeft, 1);
        float fillAmount = cdTimeLeft / button.skill.cd.cd;
        button.cooldownText.text = roundedCooldown.ToString("0.0");
        assignmentButton.cooldownText.text = roundedCooldown.ToString("0.0");
        button.mask.fillAmount = fillAmount;
        assignmentButton.mask.fillAmount = fillAmount;
    }
}
