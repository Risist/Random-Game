using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The class composes Character level and skill mamagament
 * 
 * 
 * BroadcastMessage of
 *	- void OnLvlUp(ProgressionManager manager);
 *		called when the character gets lvl up;
 *  - void OnLvlUpFate(ProgressionMnager.Fate fate);
 *		called when fate is lvled up
 */
public class ProgressionManager : MonoBehaviour
{

    public SkillPanel skillPanel;

    // Use this for initialization
    void Start()
    {
        skillPanel = GameObject.Find("SkillPanel").GetComponent<SkillPanel>();

        /// initial binding
        for (int idx = 0; idx < slots.Length; idx++)
            if (slots[idx].skillObject != null)
                BindToSlot(slots[idx].skillObject, slots[idx]);

        /// pad key code transform
        var mov = GetComponent<PlayerMovement>();
        if (mov.pad)
        {
            for (int i = 0; i < slots.Length; ++i)
                slots[i].keyCode += "_pad" + mov.playerId;
        }

        for (int idx = 0; idx < slots.Length; idx++)
        {
            if (slots[idx].skillObject != null)
            {
                BindToSlot(slots[idx].skillObject, slots[idx]);
                skillPanel.skillButtons[idx].SetSkill(slots[idx].skillObject);
            }
        }

    }


    #region Skills
    /// for holding multiply skill slots data in compact way
    [System.Serializable]
    public class SkillSlot
    {
        public string keyCode;
        public WeaponBase skillObject;
    }
    public SkillSlot[] slots = new SkillSlot[4];

    /// if given skill or slot is invalid returns false otherwise
	/// returns if slot was already binded to any skill
	public bool BindToSlot(WeaponBase skill, SkillSlot slot)
    {
        if (!skill || slot == null)
            return false;

        bool r = slot.skillObject;
        if (r)
            slot.skillObject.gameObject.SetActive(false);

        skill.gameObject.SetActive(true);
        slot.skillObject = skill;
        skill.buttonCode = slot.keyCode;

        return !r;
    }
    public bool UnbindSlot(SkillSlot slot)
    {
        bool r = slot.skillObject;
        if (r)
            slot.skillObject = null;
        return !r;
    }
    public int FindSkill(WeaponBase skill)
    {
        for (int idx = 0; idx < slots.Length; idx++)
            // If it finds slot with the same skill, returns the slot index
            if (slots[idx].skillObject == skill)
                return idx;
        return -1;
    }

    #endregion Skills

    #region lvl
    public int lvl;
    public int leftSkillPoints;
    float xp = 0.0f;
    public float requiredXpBase = 1.0f;
    public float requiredXpScale = 1.0f;
    public float GetRequiredXp() { return requiredXpBase + requiredXpScale * lvl; }

    /// Call the function instead of manually using
    public void GainXp(float amount)
    {
        xp += amount;
        while (xp > GetRequiredXp())
        {
            ++lvl;
            ++leftSkillPoints;
            xp -= GetRequiredXp();
            BroadcastMessage("OnLvlUp", this);
        }
    }
    /// in case of displaying min/max in ui
    public float GetCurrentXp() { return xp; }
    /// for fill amount in image
    public float GetXpPercentage() { return xp / GetRequiredXp(); }

    /// to not get error of "event wasn't handled"
    void OnLvlUp(ProgressionManager manager) { }
    #endregion lvl


}
