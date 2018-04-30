using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharPanelUIDisplayer : MonoBehaviour {



    ProgressionManager manager;
    EnergyController energyController;
    HealthController healthController;
    Text levelText;
    Text hpRegenText;
    Text enRegenText;
    public SkillSlot skillSlot;
    [SerializeField]
    GameObject skillContent;
    public FateInfoPanel[] fateInfoPanels;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressionManager>();
        energyController = manager.GetComponent<EnergyController>();
        healthController = manager.GetComponent<HealthController>();
        Transform charStatsInfo = gameObject.transform.Find("CharacterStatsInfo");
        levelText = charStatsInfo.transform.Find("CharacterLevelValueText").GetComponent<Text>();
        hpRegenText = charStatsInfo.transform.Find("CharacterHPRegenValueText").GetComponent<Text>();
        enRegenText = charStatsInfo.transform.Find("CharacterEnergyRegenValueText").GetComponent<Text>();
        //skillContent = GameObject.FindGameObjectWithTag("SkillBookContent");


        //// get references to fateInfoPanels
        //GameObject[] fates = GameObject.FindGameObjectsWithTag("FateInfoPanel");
        //fateInfoPanels = new FateInfoPanel[fates.Length];
        //for (int i = 0; i < fates.Length; i++)
        //{
        //    fateInfoPanels[i] = fates[i].gameObject.GetComponent<FateInfoPanel>();
        //    fateInfoPanels[i].gameObject.SetActive(false);
        //}  
        for (int i = 0; i < fateInfoPanels.Length; i++)
        {
            fateInfoPanels[i].gameObject.SetActive(false);
        }
    }


    // Use this for initialization
    void Start ()
    {
        // Instantiate skillslots in skill book for every skill player has
        foreach (var skill in manager.unlockedSkills)
        {
            InstantiateSkillSlot(skill);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        levelText.text = manager.lvl.ToString();
        hpRegenText.text = healthController.regeneration.ToString();
        enRegenText.text = energyController.regeneration.ToString();
    }

    // Function for instantiating skillSlot in skill book
    public SkillSlot InstantiateSkillSlot(WeaponBase skill)
    {
        var sSlot = Instantiate(skillSlot) as SkillSlot;
        sSlot.Skill = skill;
        sSlot.gameObject.SetActive(true);
        sSlot.SkillNameText.text = skill.displayName.ToString();
        sSlot.SkillIcon.sprite = skill.skillIcon;
        sSlot.SkillDescriptionText.text = skill.description.ToString();
        sSlot.SkillCostText.text = "EN: " + skill.cost.ToString();
        sSlot.gameObject.transform.SetParent(skillContent.transform, false);

        return sSlot;
    }

    // Insert learned fate in the first free fate slot 
    public void InitializeFateInfoPanel(ProgressionManager.Fate fate)
    {
        for (int idx = 0; idx < fateInfoPanels.Length; idx++)
            if (!fateInfoPanels[idx].IsOccupied)
            {
                FillFateInfoPanel(fateInfoPanels[idx], fate);
                return;
            }

        Debug.Log("All fate slots occupied!\n");

    }

    public void UpgradeFateInfoPanel(ProgressionManager.Fate fate)
    {
        for (int idx = 0; idx < fateInfoPanels.Length; idx++)
        {
            //Debug.Log(fateInfoPanels[idx].Name.text);
            if (fateInfoPanels[idx].Name.text == "Fate: " + fate.Name)
            {
                UpgradeFateInfoPanel(fateInfoPanels[idx], fate);
                return;
            }
        }
        Debug.Log("ERROR: UpgradeFateInfoPanel\n");

    }

    void FillFateInfoPanel(FateInfoPanel panel, ProgressionManager.Fate fate)
    {
        panel.gameObject.SetActive(true);
        panel.IsOccupied = true;
        panel.Name.text = "Fate: " + fate.Name;
        panel.Level.text = "Level: " + fate.Lvl.ToString();
        panel.Icon.overrideSprite = fate.Icon;
        panel.Description.text = fate.Description;
        panel.Description.text = fate.Description;
    }

    // Upgrade FateInfoPanel information, doesn't affect chosenFates fields 
    void UpgradeFateInfoPanel(FateInfoPanel panel, ProgressionManager.Fate fate)
    {
       
        Debug.Log("UpgradeFateSlot: upgrade FateInfoPanel " + panel.Name);

        // Find the matching fate from chosenFates


        panel.Level.text = "Level: " + fate.Lvl.ToString();
        panel.Description.text = fate.Description;
        
    }

}
