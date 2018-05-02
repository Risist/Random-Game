using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BroadcastMessage of
 *	- void OnLvlUp(ProgressionManager manager);
 *		called when the character gets lvl up;
 *  - void OnLvlUpFate(ProgressionMnager.Fate fate);
 *		called when fate is lvled up
 */
public class ProgressionManager : MonoBehaviour {

    public SkillPanel skillPanel;
    public SkillPanel assignmentPanel;

    private void Awake()
    {
        skillPanel = GameObject.Find("SkillPanel").GetComponent<SkillPanel>();
        //assignmentPanel = GameObject.Find("SkillAssignmentPanel").GetComponent<SkillPanel>();
 
    }


    private void Start()
	{
        possibleSkills = GetComponentsInChildren<WeaponBase>();


        possibleFateNames = new string[6];
        possibleFateNames[0] = "Melee";
        possibleFateNames[1] = "Hunter";
        possibleFateNames[2] = "Devil";
        possibleFateNames[3] = "Void";
        possibleFateNames[4] = "Earth";
        possibleFateNames[5] = "Wind";


        /// pad key code transform
        var mov = GetComponent<PlayerMovement>();
        if (mov.pad)
        {
            for (int i = 0; i < slots.Length; ++i)
                slots[i].keyCode += "_pad" + mov.playerId;
        }

        /// initial binding
        for (int idx = 0; idx < slots.Length; idx++)
        {
            if (slots[idx].skillObject != null)
            {
                BindToSlot(slots[idx].skillObject, slots[idx]);
                skillPanel.skillButtons[idx].SetSkill(slots[idx].skillObject);
                assignmentPanel.skillButtons[idx].SetSkill(slots[idx].skillObject);
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
		while(xp > GetRequiredXp() )
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
	public float GetXpPercentage() { return xp / GetRequiredXp();  }

	/// to not get error of "event wasn't handled"
	void OnLvlUp(ProgressionManager manager){}
#endregion lvl


#region Fate
	[System.Serializable]
	public class Fate
	{
		public string name;
		public int lvl;
        public Sprite icon;
        public string description;
        public bool isInSelectionSlot;

        [System.NonSerialized]
		public ProgressionManager manager;
	}
	string[] possibleFateNames;
	public string GetRandomFateName() { return possibleFateNames[Random.Range(0, possibleFateNames.Length)]; }
	public string GetRandomLockedFateName()
	{
		List<string> names = new List<string>();
		foreach (var it in possibleFateNames)
			if (it != chosenFates[0].name && it != chosenFates[1].name)
				names.Add(it);
		return names[Random.Range(0, names.Count)];
	}

	public int maxFateLvl = 5;
	public Fate[] chosenFates = new Fate[2];

	public bool IsFateUnlocked(string name) { return chosenFates[0].name == name || chosenFates[1].name == name; }

	// unlocks a fate with specified name
	//public bool UnlockFate(string name)
	//{
	//	if (chosenFates[0] == null || chosenFates[0].name == "" )
	//	{
	//		chosenFates[0].name = name;
	//		chosenFates[0].lvl = 0;
	//		chosenFates[0].manager = this;

	//		LvlUpFate(0);
	//		return true;
	//	} else if(chosenFates[1] == null || chosenFates[1].name == "")
	//	{
	//		chosenFates[1].name = name;
	//		chosenFates[1].lvl = 0;
	//		chosenFates[1].manager = this;

	//		LvlUpFate(1);
	//		return true;
	//	}

	//	return false;
	//}

	// lvl ups given fate. If fate has max lvl returns false instead; Returns false in case if fate is invalid or not choosen as a path or not having enough skillpoints
	//public bool LvlUpFate(int id) { return LvlUpFate(chosenFates[id]); }
	//public bool LvlUpFate(Fate fate)
	//{
	//	if (fate == null || leftSkillPoints <= 1)
	//		return false;

	//	--leftSkillPoints;

	//	if(fate.lvl < maxFateLvl)
	//	{
	//		++fate.lvl;
	//		BroadcastMessage("OnLvlUpFate", fate);
	//		return true;
	//	}
	//	return false;
	//}

	/// event receiver to avoid "unhandled event" error
	void OnLvlUpFate(Fate fate){}

    [SerializeField]
    List<Fate> possibleFates;

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
            if (("Fate: " + possibleFates[idx].name) == name)
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
            if (!((FindChosenFate(it) != -1) || it.isInSelectionSlot))
            {
                unchosenFates.Add(it);
                Debug.Log("GetRandomUnchosenFate: Added " + it.name);

            }

        int randomIdx = Random.Range(0, unchosenFates.Count);
        possibleFates[randomIdx].isInSelectionSlot = true;

        return unchosenFates[randomIdx];
    }

    public bool UnlockFate(string name) { return UnlockFate(GetFateByName(name)); }
    public bool UnlockFate(Fate fate)
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
            if (chosenFates[idx] == null)
            {
                Debug.Log("UnlockFate: Assigned fate " + fate.name + " to chosenFates[" + idx + "]");
                chosenFates[idx] = fate;
                --leftSkillPoints;

                // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
                gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

                return true;
            }

        //Debug.Log("UnlockFate: ERROR: No chosenFates slot selected!");
        return false;
    }

    // Find fate in chosenFate and return index of slot
    public int FindChosenFate(string name) { return FindChosenFate(GetFateByName(name)); }
    public int FindChosenFate(Fate fate)
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
        {
            // Null values guard
            if (chosenFates[idx] == null)
                continue;

            if (chosenFates[idx].name == fate.name)
            {
                //Debug.Log("FindChosenFate(fate): Found fate " + fate.name + " at chosenFates[" + idx + "]");
                return idx;
            }
        }
        //Debug.Log("FindChosenFate(fate): Did not found fate " + fate.name);
        return -1;
    }

    public bool IsChosenFatesFull()
    {
        for (int idx = 0; idx < chosenFates.Length; idx++)
        {
            if (chosenFates[idx] == null)
            {
                Debug.Log("IsChosenFatesFull: found empty slot in chosenFates[" + idx + "]");
                return false;
            }
        }

        Debug.Log("IsChosenFatesFull: chosenFates array if full");
        return true;
    }

    // UpgradeFate by increasing its level and adding fate bonus to Player component <FateUpgrade>
    public bool LvlUpFate(string name) { return LvlUpFate(GetFateByName(name)); }
    public bool LvlUpFate(Fate fate)
    {
        // Return false if fate is null
        if (fate == null)
            return false;

        // Find index of chosen fate to upgrade
        int idx = FindChosenFate(fate);

        // If we found same fate in chosenFates, we have skillPoints and fate level is not max
        if (idx != -1 && leftSkillPoints > 0 && chosenFates[idx].lvl < maxFateLvl)
        {
            --leftSkillPoints;
            ++chosenFates[idx].lvl;

            //BroadcastMessage("OnLvlUpFate", fate);

            // Call OnLvlUpFate method of component <FateUpgrade> to add fate bonus of upgraded fate
            gameObject.GetComponent<FateUpgrader>().OnLvlUpFate(chosenFates[idx]);

            Debug.Log("UpgradeFate: Upgraded fate " + chosenFates[idx].name + " at chosenFates[" + idx + "]");
            return true;

        }

        return false;

    }


    #endregion Fate

    #region Skills
    /// for holding multiply skill slots data in compact way
    [System.Serializable]
	public class SkillSlot
	{
		public string keyCode;
		public WeaponBase skillObject;
	}

	public SkillSlot[] slots = new SkillSlot[4];
	/// list of currently unlocked skills. Maintained by this script with possibility to set up initial ones in inspector; 
	public List<WeaponBase> unlockedSkills;
	/// list of all possible skills. Seted up by the scriot with all the child obhects containing WeaponBase inherited sctipt;
	//[System.NonSerialized]
    [SerializeField]
	public WeaponBase[] possibleSkills;

	/// returns whether given skill is unlocked
	public bool IsUnlocked(int id) { return IsUnlocked(possibleSkills[id]); }
	public bool IsUnlocked(WeaponBase weapon)
	{
		foreach (var it in unlockedSkills)
			if (it == weapon)
				return true;
		return false;
	}

	// unlocks given skill. If already unlocked returns false; if skill doesn't meet the requirements returns false.
	public bool UnlockSkill(int id) { return UnlockSkill(possibleSkills[id]); }
	public bool UnlockSkill(WeaponBase weapon)
	{
		if (leftSkillPoints <=1 || IsUnlocked(weapon) || !weapon.MeetsRequirements())
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
        if(r)
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


    public WeaponBase GetRandomLockedSkill()
	{
		List<WeaponBase> skills = new List<WeaponBase>();
		foreach (var it in possibleSkills)
			if (!it.isUnlocked)
				skills.Add(it);
		return skills[Random.Range(0,skills.Count)];
	}

#endregion Skills

}
