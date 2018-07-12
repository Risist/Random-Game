using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {

#region Settings
    public bool padControll;
    public int padId = 1;

    public string xAxisCode = "Horizontal";
    public string yAxisCode = "Vertical";
    /// rotation axis (revelant to pad only)
    public string xControlAxisCode = "Horizontal2";
    public string yControlAxisCode = "Vertical2";

    public string primaryAxisCode = "Vertical2";
    public string secondaryAxisCode = "Vertical2";
    public string ultimateAxisCode = "Vertical2";
    public string movementAxisCode = "Vertical2";


    #endregion Settings

    PlayerMovement movement;
    ItemManager items;

    private void Update()
    {
        /// input apply
        if (Input.GetButton(primaryAxisCode))
            items.press(ItemManager.ESkillRole.primary);
        if (Input.GetButton(secondaryAxisCode))
            items.press(ItemManager.ESkillRole.secondary);
        if (Input.GetButton(ultimateAxisCode))
            items.press(ItemManager.ESkillRole.ultimate);
        if (Input.GetButton(movementAxisCode))
            items.press(ItemManager.ESkillRole.movement);


    }

}
