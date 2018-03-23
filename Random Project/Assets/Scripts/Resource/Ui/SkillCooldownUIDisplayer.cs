using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCooldownUIDisplayer : MonoBehaviour {

    public bool updateProgress = true;
    ProgressionManager manager;
    public int skillNum;
    public WeaponBase skill;
    public Image skillPanelMaskImage;
    public Image charPanelMaskImage;
    public Text charPanelCdText;
    public Text skillPanelCdText;

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressionManager>();
        skill = manager.slots[skillNum].skillObject;
        skillPanelMaskImage = GetComponentsInChildren<Image>()[1];
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
        skillPanelCdText.enabled = false;
        charPanelCdText.enabled = false;
        skillPanelMaskImage.enabled = false;
        charPanelMaskImage.enabled = false;
    }

    private void SkillCooldown()
    {
        skillPanelCdText.enabled = true;
        skillPanelMaskImage.enabled = true;
        charPanelCdText.enabled = true;
        charPanelMaskImage.enabled = true;

        float cdTimeLeft = skill.cd.actualTime + skill.cd.cd - Time.time;
        float roundedCooldown = Mathf.Round(cdTimeLeft);
        float fillAmount = cdTimeLeft / skill.cd.cd;
        skillPanelCdText.text = roundedCooldown.ToString();
        charPanelCdText.text = roundedCooldown.ToString();
        skillPanelMaskImage.fillAmount = fillAmount;
        charPanelMaskImage.fillAmount = fillAmount;
    }
}
