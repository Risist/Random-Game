using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LvlUpPanelUIDisplayer : MonoBehaviour
{
    ProgressionManager manager;
    public FateSelectionSlot[] fateSelectionSlots;
    public SkillSelectionSlot[] skillSelectionSlots;
    public CharPanelUIDisplayer charPanel;
    public GameObject fateSlot;
    //public int fateSlotsLeft;
    public Text skillPoints;
    public Button acceptButton;
    public ToggleGroup toggleGroup;

    private void Awake()
    {


        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressionManager>();
        skillPoints = gameObject.transform.Find("SelectionBlock").Find("PointsValueText").GetComponent<Text>();
        skillPoints.text = manager.leftSkillPoints.ToString();
        acceptButton = gameObject.transform.Find("AcceptButton").GetComponent<Button>();
        toggleGroup = gameObject.transform.Find("SelectionBlock").GetComponent<ToggleGroup>();

        //// get possible locked fates
        //GameObject[] fates = GameObject.FindGameObjectsWithTag("FateSelectionSlot");
        //fateSelectionSlots = new FateSelectionSlot[fates.Length];
        //for (int i = 0; i < fates.Length; i++)
        //    fateSelectionSlots[i] = fates[i].gameObject.GetComponent<FateSelectionSlot>();

        //// get possible locked skills
        //GameObject[] skills = GameObject.FindGameObjectsWithTag("SkillSelectionSlot");
        //skillSelectionSlots = new SkillSelectionSlot[skills.Length];
        //for (int i = 0; i < skills.Length; i++)
        //    skillSelectionSlots[i] = skills[i].gameObject.GetComponent<SkillSelectionSlot>();

        SetSkillSlotsInteractive(false);
        SetFateSlotsInteractive(false);
        acceptButton.interactable = false;



    }


    // Use this for initialization
    void Start()
    {

        for(int i = 0; i < fateSelectionSlots.Length; i++)
            GenerateRandomFateSlot(fateSelectionSlots[i]);

        for (int i = 0; i < skillSelectionSlots.Length; i++)
            GenerateRandomSkillSlot(skillSelectionSlots[i]);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // If player has skillPoints 
        if (manager.leftSkillPoints > 0)
        {
            for(int idx = 0; idx < fateSelectionSlots.Length; idx++)
            {
                // If we have such skill in chosenFates and it is max level, set to false
                if (manager.FindChosenFate(fateSelectionSlots[idx].Name.text) != -1 && 
                    manager.chosenFates[manager.FindChosenFate(fateSelectionSlots[idx].Name.text)].lvl >= manager.maxFateLvl) 
                {
                    SetFateSlotInteractive(fateSelectionSlots[idx], false);
                    continue;
                }
                else
                    // In every other case if will be active
                    SetFateSlotInteractive(fateSelectionSlots[idx], true);

            }

            SetSkillSlotsInteractive(true);
            acceptButton.interactable = true;
        }

        else
        {
            SetSkillSlotsInteractive(false);
            SetFateSlotsInteractive(false);
            acceptButton.interactable = false;
        } 

    }

    // When player presses accept button
    public void OnSubmit()
    {
        // Check if any toggle was active
        if (toggleGroup.ActiveToggles().Count() == 0)
            return;

        // If player have skillPoints
        if (manager.leftSkillPoints > 0)
        {
            // Take selected slot 
            var selectedToggle = toggleGroup.ActiveToggles().First();

            //Debug.Log("OnSubmit: Submit button clicked. " + selectedToggle.name + " is selected");
            toggleGroup.SetAllTogglesOff();

            // If selected slot was Skill slot
            if (selectedToggle.GetComponentInParent<SkillSelectionSlot>())
            {
                // Get references to SkillSelectionSlot and WeaponBase from selected toggle
                SkillSelectionSlot skillSlot = selectedToggle.GetComponentInParent<SkillSelectionSlot>();
                WeaponBase skill = selectedToggle.GetComponentInParent<SkillSelectionSlot>().Skill;

                // Instantiate a new SkillSlot with learned skill in Skill book in CharPanel 
                charPanel.InstantiateSkillSlot(skill);


                // Generate new random SkillSlot in LvlUpPanel
                GenerateRandomSkillSlot(skillSlot);

                // Unlock skill fro manager
                manager.UnlockSkill(skill);
            }

            // If selected slot was Fate slot
            else if (selectedToggle.GetComponentInParent<FateSelectionSlot>())
            {
                // Get references to FateSelectionSlot and Fate from selected toggle
                FateSelectionSlot fateSlot = selectedToggle.GetComponentInParent<FateSelectionSlot>();
                ProgressionManager.Fate selectedFate = manager.GetFateByName(fateSlot.Name.text);

                //If there is no such fate in chosen fates
                if (manager.FindChosenFate(selectedFate) == -1)
                {
                    //Debug.Log("OnSubmit: create new fateInfoPanel for " + selectedFate.Name);

                    // Unlock a new fate
                    manager.UnlockFate(selectedFate);

                    // Instantiate a new fateInfoPanel in charPanel
                    charPanel.InitializeFateInfoPanel(selectedFate);

                }
                // else upgrade the current fate in chosen fates
                else
                {
                    //Debug.Log("OnSubmit: update fateInfoPanel for " + selectedFate.Name);

                    // Upgrade existing fate
                    manager.LvlUpFate(selectedFate);

                    // Upgrade a FateInfoPanel in CharacterPanel
                    charPanel.UpgradeFateInfoPanel(selectedFate);

                }

                // Update UI for fate
                UpgradeFateSlot(fateSlot, selectedFate);


            }

            // Update UI skill points value
            skillPoints.text = manager.leftSkillPoints.ToString();
        }
    }

    void SetSkillSlotInteractive(SkillSelectionSlot slot, bool mode)
    {
        slot.GetComponent<Toggle>().interactable = mode;
    }

    void SetFateSlotInteractive(FateSelectionSlot slot, bool mode)
    { 
        slot.GetComponent<Toggle>().interactable = mode;
    }

    void SetSkillSlotsInteractive(bool mode)
    {
        foreach (var slot in skillSelectionSlots)
            slot.GetComponent<Toggle>().interactable = mode;
    }

    void SetFateSlotsInteractive(bool mode)
    {
        foreach (var slot in fateSelectionSlots)
            slot.GetComponent<Toggle>().interactable = mode;
    }

    // Set skill/fate selection slot interactibility on/off 
    //void SetToggleInteractible(Toggle toggle, bool mode)
    //{
    //    toggle.interactable = mode;
    //}


    // Generate rangom FateSelectionSlots by picking random unchosen fate from list and applying its properties to slot 
    void GenerateRandomFateSlot(FateSelectionSlot slot)
    {
        ProgressionManager.Fate fate = manager.GetRandomUnchosenFate();
        //slot.Fate = fate;
        //Debug.Log("GenerateRandomFateSlot: got fate " + fate.Name + " from unchosen fates");
        slot.Name.text = "Fate: " + fate.name;
        slot.Level.text = "Level: " + fate.lvl.ToString();
        slot.Icon.overrideSprite = fate.icon;
        slot.Description.text = fate.description;
    }

    // Upgrade FateSelectionSlot information, doesn't affect chosenFates fields 
    void UpgradeFateSlot(FateSelectionSlot slot, ProgressionManager.Fate fate)
    {
        if(slot.Level.text != "Level: " + manager.maxFateLvl.ToString())
        {
            //Debug.Log("UpgradeFateSlot: upgrade FateSelectionSlot " + slot.Name);

            // Find the matching fate from chosenFates
            

            slot.Level.text = "Level: " + (fate.lvl + 1).ToString();
            slot.Description.text = fate.description;
        }

    }

    bool IsInSkillSelectionSlot(WeaponBase slot)
    {
        for (int idx = 0; idx < skillSelectionSlots.Length; idx++)
            if (skillSelectionSlots[idx].Skill == slot)
                return true;

        return false;
    }

    void GenerateRandomSkillSlot(SkillSelectionSlot slot)
    {
        WeaponBase skill;
        do
        {
            skill = manager.GetRandomLockedSkill();
        } while (IsInSkillSelectionSlot(skill));

        //Debug.Log("Got " + skill.displayName.ToString() + " skill");
        slot.Skill = skill;
        slot.Name.text = skill.displayName.ToString();
        //slot.Level.text = "Level: " + skill.level.ToString();
        slot.Icon.overrideSprite = skill.skillIcon;
        slot.Cost.text = "En: " + skill.cost.ToString();
        slot.Description.text = skill.description.ToString();

    }



}
