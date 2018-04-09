using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Sprite defaultSprite;
    [HideInInspector]
    public WeaponBase skill;
    [HideInInspector]
    public Image icon;
    [HideInInspector]
    public Image mask;
    [HideInInspector]
    public Text cooldownText;

    public void Start()
    {
        
    }

    private void Awake()
    {
        icon = gameObject.GetComponentsInChildren<Image>(true)[0];
        mask = gameObject.GetComponentsInChildren<Image>(true)[1];
        cooldownText = gameObject.GetComponentInChildren<Text>(true);
        //icon.overrideSprite = defaultSprite;
        cooldownText.enabled = false;
    }

    public void SetSkill(WeaponBase skill)
    {
        this.skill = skill;
        icon.overrideSprite = skill.skillIcon;
        cooldownText.enabled = true;
    }

    public void UnsetSkill()
    {
        icon.overrideSprite = defaultSprite;
        skill = null;
        cooldownText.enabled = false;
    }


}
