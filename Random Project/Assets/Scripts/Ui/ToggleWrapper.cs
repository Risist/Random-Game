using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWrapper : MonoBehaviour {

    
    public Toggle toggle;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        toggle.isOn = playerMovement.pad;
        toggle.onValueChanged.AddListener(ListenerMethod);
    }

    public void ListenerMethod(bool value)
    {
        playerMovement.setPad(toggle.isOn);
    }
}
