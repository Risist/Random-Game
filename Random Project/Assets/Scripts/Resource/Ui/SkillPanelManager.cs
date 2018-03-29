using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelManager : MonoBehaviour {

    GameObject skillPanel;
    GameObject charSkillPanel;
    GameObject[] skillPanelSlots;
    GameObject[] charPanelSkillSlots;


    // Use this for initialization
    void Awake()
    {
        skillPanel = GameObject.FindGameObjectWithTag("SkillPanel");
        charSkillPanel = GameObject.FindGameObjectWithTag("SkillAssignmentPanel");

        
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
