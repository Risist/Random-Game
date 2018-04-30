using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * BroadcastMessage of
 *	- void OnLvlUp(ProgressionManager manager);
 *		called when the character gets lvl up;
 *  - void OnLvlUpFate(ProgressionMnager.Fate fate);
 *		called when fate is lvled up
 */
public class ProgressionManager : MonoBehaviour {

    [SerializeField]
    SkillPanel skillPanel;
    [SerializeField]
    SkillPanel assignmentPanel;



    private void Awake()
    {
        skillPanel = GameObject.Find("SkillPanel").GetComponent<SkillPanel>();



        //assignmentPanel = GameObject.Find("SkillAssignmentPanel").GetComponent<SkillPanel>();
        //possibleSkills = GetComponentsInChildren<WeaponBase>();
        //WeaponBase[] obj = GetComponentsInChildren<WeaponBase>();
        //for (int i = 0; i < obj.Length; i++)
        //    obj[i].gameObject.SetActive(true);

        // fates initialization
        chosenFates = new Fate[2] { null, null };
        possibleFateNames = new string[] { "Melee", "Hunter", "Devil", "Wind", "Earth"/*, "Void"*/ };

        possibleFateDescription = new string[] { "Increases max HP", "Increases movement speed",
                                                 "Increases max energy", "Increases energy regeneration",
                                                 "Increases HP regeneration", /*"Increases XP gained"*/ };

        possibleFates = new List<Fate>();
        slots = new SkillSlot[4]
        {
            new SkillSlot("Fire1"),
            new SkillSlot("Fire2"),
            new SkillSlot("Fire3"),
            new SkillSlot("Movement")
        };

        //Debug.Log(ProgressionManager Awake: possibleFateNames.Length);
        for (int i = 0; i < possibleFateNames.Length; i++)
        {
            possibleFates.Add(new Fate(possibleFateNames[i], possibleFateIcons[i], possibleFateDescription[i]));
            //Debug.Log("ProgressionManager Awake: possibleFates[" + i + "] = " + possibleFates[i].Name);
        }

    }


    private void Start()
    {

        /// initial skill binding
        for (int idx = 0; idx < slots.Length; idx++)
        {
            if (slots[idx].SkillObject)
            {
                BindToSlot(slots[idx].SkillObject, slots[idx]);
                skillPanel.skillButtons[idx].SetSkill(slots[idx].SkillObject);
                assignmentPanel.skillButtons[idx].SetSkill(slots[idx].SkillObject);
            }
        }
    }

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


    #region Fate
    //[System.Serializable]
    public class Fate
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public Sprite Icon { get; set; }
        public string Description { get; set; }
        public bool IsInSelectionSlot { get; set; }


        [System.NonSerialized]
        public ProgressionManager manager;


        public Fate(string name, Sprite icon, string description)
        {
            Name = name;
            Lvl = 1;
            Icon = icon;
            Description = description;
        }
    }

    //[SerializeField]
    List<Fate> possibleFates;
    [SerializeField]
    string[] possibleFateNames;
    [SerializeField]
    Sprite[] possibleFateIcons;
    [SerializeField]
    string[] possibleFateDescription;

    public int fateMaxLvl = 5;

    // Array of fates chosen by player
    public Fate[] chosenFates;


    // Get random fate from all possible fates (chosen and not)
    public Fate GetRandomFate()
    {
        return possibleFates[Random.Range(0, possibleFates.Count)];
    }

    // Get fate by it's name
    public Fate GetFateByName(string name)
    {
        for (int idx = 0; idx < possibleFates.Count; idx++)
        {
            if (("Fate: " + possibleFates[idx].Name) == name)
            {
                //Debug.Log("GetFateByName: found fate " + name + " at " + idx);
                return possibleFates[idx];
            }
        }
        //Debug.Log("GetFateByName: Fate with such name wasn't found");
        return null;
    }

    // Get random fate from all unchosen fates
    public Fate GetRandomUnchosenFate()
    {
        List<Fate> unchosenFates = new List<Fate>();
        foreach (var it in possibleFates)
            if (!((FindChosenFate(it) != -1) || it.IsInSelectionSlot))
            {
                unchosenFates.Add(it);
                //Debug.Log("GetRandomUnchosenFate: Added " + it.Name);

            }

        int randomIdx = Random.Range(0, unchosenFates.Count);
        possibleFates[randomIdx].IsInSelectionSlot = true;

        return unchosenFates[randomIdx];
    }

    // Check if fate has been chosen by player
    //public bool IsFateChosen(Fate fate)
    //{
    //    return chosenFates[0] == fate || chosenFates[1] == fate;
    //}

    // Assign fate to free chosenFates slot
    public bool UnlockFate(Fate fate)
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
            if (chosenFates[idx] == null)
            {
                //Debug.Log("UnlockFate: Assigned fate " + fate.Name + " to chosenFates[" + idx + "]");
                chosenFates[idx] = fate;
                --leftSkillPoints;

                // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
                gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

                return true;
            }

        //Debug.Log("UnlockFate: ERROR: No chosenFates slot selected!");
        return false;
    }

    // Assign fate by name to free chosenFates slot
    public bool UnlockFate(string name)
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
            if (chosenFates[idx] == null)
            {
                //Debug.Log("UnlockFate: Assigned fate " + name + " to chosenFates[" + idx + "]");
                chosenFates[idx] = GetFateByName(name);
                --leftSkillPoints;

                // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
                gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

                return true;
            }

        //Debug.Log("UnlockFate: ERROR: No chosenFates slot selected!");
        return false;
    }


    // Find fate in chosenFate and return index of slot
    public int FindChosenFate(Fate fate)
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
        {
            // Null values guard
            if (chosenFates[idx] == null)
                continue;

            if (chosenFates[idx].Name == fate.Name)
            {
                //Debug.Log("FindChosenFate(fate): Found fate " + fate.Name + " at chosenFates[" + idx + "]");
                return idx;
            }
        }
        //Debug.Log("FindChosenFate(fate): Did not found fate " + fate.Name);
        return -1;
    }

    // Find fate in chosenFate by fate name and return index of slot
    public int FindChosenFate(string name)
    {

        for (int idx = 0; idx < chosenFates.Length; idx++)
        {
            // Null values guard
            if (chosenFates[idx] == null)
                continue;

            if (("Fate: " + chosenFates[idx].Name) == name)
            {
                //Debug.Log("FindChosenFate(string): Found fate " + chosenFates[idx].Name + " at chosenFates[" + idx + "]");
                return idx;
            }
        }
        //Debug.Log("FindChosenFate(string): Did not found " + name);
        return -1;
    }

    public bool IsChosenFatesFull()
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
        {
            if (chosenFates[idx] == null)
            {
                //Debug.Log("IsChosenFatesFull: found empty slot in chosenFates[" + idx + "]");
                return false;
            }
        }

        //Debug.Log("IsChosenFatesFull: chosenFates array if full");
        return true;
    }

    // UpgradeFate by increasing its level and adding fate bonus to Player component <FateUpgrade>
    public bool UpgradeFate(Fate fate)
    {
        // Return false if fate is null
        if (fate == null)
            return false;

        // Find index of chosen fate to upgrade
        int idx = FindChosenFate(fate);

        // If we found same fate in chosenFates, we have skillPoints and fate level is not max
        if (idx != -1 && leftSkillPoints > 0 && chosenFates[idx].Lvl < fateMaxLvl)
        {
            --leftSkillPoints;
            ++chosenFates[idx].Lvl;

            //BroadcastMessage("OnLvlUpFate", fate);

            // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
            gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

            //Debug.Log("UpgradeFate: Upgraded fate " + chosenFates[idx].Name + " at chosenFates[" + idx + "]");
            return true;

        }

        return false;

    }

    // UpgradeFate by name by increasing its level and adding fate bonus to Player component <FateUpgrade>
    public bool UpgradeFate(string name)
    {
        // Return false if fate is null
        if (name == null)
            return false;

        // Find index of chosen fate to upgrade
        int idx = FindChosenFate(name);

        // If we found same fate in chosenFates, we have skillPoints and fate level is not max
        if (idx != -1 && leftSkillPoints > 0 && chosenFates[idx].Lvl < fateMaxLvl)
        {
            --leftSkillPoints;
            ++chosenFates[idx].Lvl;

            //BroadcastMessage("OnLvlUpFate", fate);

            // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
            gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

            //Debug.Log("UpgradeFate: Upgraded fate " + chosenFates[idx].Name + " at chosenFates[" + idx + "]");
            return true;

        }

        return false;

    }

    /// event receiver to avoid "unhandled event" error
    void OnLvlUpFate(Fate fate) { }

    #endregion Fate

    #region Skills

    /// Helper class for holding multiply skill slots data in compact way
    [System.Serializable]
    public class SkillSlot
    { 
        public string KeyCode { get; set; }
        public WeaponBase SkillObject { get; set; }

        public SkillSlot(string key, WeaponBase skill = null)
        {
            KeyCode = key;
            SkillObject = skill;
        }
    }

    // Slots for assigned skills
   
    public SkillSlot[] slots;

    /// list of currently unlocked skills. Maintained by this script with possibility to set up initial ones in inspector; 
    public List<WeaponBase> unlockedSkills;

    /// list of all possible skills. Seted up by the scriot with all the child obhects containing WeaponBase inherited sctipt;
    //[System.NonSerialized]
    public WeaponBase[] possibleSkills;

    // Get random skill from list of possible skills
    public WeaponBase GetRandomPossibleSkill()
    {
        List<WeaponBase> skills = new List<WeaponBase>();
        foreach (var it in possibleSkills)
            if (!it.isUnlocked)
                skills.Add(it);
        return skills[Random.Range(0, skills.Count)];
    }

    /// returns whether given skill is unlocked
    //public bool IsUnlocked(int id) { return IsUnlocked(possibleSkills[id]); }
    public bool IsUnlocked(WeaponBase skill)
	{
		foreach (var unlockedSkill in unlockedSkills)
			if (unlockedSkill == skill)
				return true;
		return false;
	}

    // unlocks given skill. If already unlocked returns false; if skill doesn't meet the requirements returns false.
    //public bool UnlockSkill(int id) { return UnlockSkill(possibleSkills[id]); }

    public bool UnlockSkill(WeaponBase weapon)
	{
		if (/*leftSkillPoints <= 0 ||*/ IsUnlocked(weapon) /*|| /*!weapon.MeetsRequirements()*/)
			// the skill is already unlocked
			// or skill cant be unlocked yet
			// or not enough skillPoints left
			return false;

		unlockedSkills.Add(weapon);
        --leftSkillPoints;
        weapon.isUnlocked = true;
		return true;
	}

	/// if given skill or slot is invalid returns false otherwise
	/// returns if slot was already binded to any skill
	public bool BindToSlot(WeaponBase skill, SkillSlot slot)
	{
		if (!skill || slot == null)
			return false;

        bool r = slot.SkillObject;
        if (r)
            slot.SkillObject.gameObject.SetActive(false);

        skill.gameObject.SetActive(true);
		slot.SkillObject = skill;
		skill.buttonCode = slot.KeyCode;

        return !r;
    }

    public bool UnbindSlot(SkillSlot slot)
    {
        bool r = slot.SkillObject;
        if(r)
            slot.SkillObject = null;
        return !r;
    }

    public int FindSkill(WeaponBase skill)
    {
        for (int idx = 0; idx < slots.Length; idx++)
            // If it finds slot with the same skill, returns the slot index
            if (slots[idx].SkillObject == skill)
                return idx;
        return -1;
    }




#endregion Skills

}
