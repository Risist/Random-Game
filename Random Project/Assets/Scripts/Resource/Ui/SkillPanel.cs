using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    [HideInInspector]
    public SkillButton[] skillButtons;


    private void Awake()
    {
        skillButtons = gameObject.GetComponentsInChildren<SkillButton>();    
    }

    public void SetSkill(int idx, WeaponBase skill)
    {
        if(idx >= 0 && idx < skillButtons.Length)
            skillButtons[idx].SetSkill(skill);
    }

    public void UnsetSkill(int idx)
    {
        if (idx >= 0 && idx < skillButtons.Length)
            skillButtons[idx].UnsetSkill();
    }

}
