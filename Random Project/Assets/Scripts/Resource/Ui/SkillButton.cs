using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Sprite defaultSprite;
    [HideInInspector]
    public WeaponBase skill;
    Image icon;
    [HideInInspector]
    public Image mask;
    [HideInInspector]
    public Text cooldownText;


    private void Awake()
    {
        icon = gameObject.GetComponentsInChildren<Image>()[0];
        mask = gameObject.GetComponentsInChildren<Image>()[1];
        cooldownText = gameObject.GetComponentInChildren<Text>();
        icon.overrideSprite = defaultSprite;
        cooldownText.enabled = false;
    }

    public void SetSkill(WeaponBase skill)
    {
        icon.overrideSprite = skill.skillIcon;
        this.skill = skill;
        cooldownText.enabled = true;
    }

    public void UnsetSkill()
    {
        icon.overrideSprite = defaultSprite;
        skill = null;
        cooldownText.enabled = false;
    }


}
