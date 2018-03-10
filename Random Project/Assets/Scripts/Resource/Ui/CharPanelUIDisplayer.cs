using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharPanelUIDisplayer : MonoBehaviour {



    public ProgressionManager manager;
    EnergyController energyController;
    HealthController healthController;
    public Text levelText;
    public Text hpRegenText;
    public Text enRegenText;

    // Use this for initialization
    void Start ()
    {
        energyController = manager.GetComponent<EnergyController>();
        healthController = manager.GetComponent<HealthController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        levelText.text = manager.lvl.ToString();
        hpRegenText.text = healthController.regeneration.ToString();
        enRegenText.text = energyController.regeneration.ToString();
    }
}
