using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

#region Input
    public enum ESkillRole
    {
        primary,
        secondary,
        ultimate,
        movement,
        count
    }
    bool[] inputRecord = new bool[(int)ESkillRole.count];
    public bool isPressed(ESkillRole role) { return inputRecord[(int)role]; }
    public void press(ESkillRole role) { inputRecord[(int)role] = true;  }
#endregion Input
    

#region Equipment

    /// TODO
    [System.Serializable]
    public class Item
    {
        ItemAbilityBase[] skills;
    }

    public Item[] equipment;
    int currentItemIdx = 0;
    public Item GetCurrentItem() { return equipment[currentItemIdx]; }
    public void swapItemLeft() { currentItemIdx = (currentItemIdx - 1) % equipment.Length; }
    public void swapItemRight() { currentItemIdx = (currentItemIdx + 1) % equipment.Length; }

    public void dropCurrentItem()
    {
        /// Placeholder!!!!!!!!!
        equipment[currentItemIdx] = null;
    }
    public void collectItem(Item item)
    {
        for(int i = 0; i < equipment.Length; ++i)
            if(equipment[ (currentItemIdx + i) % equipment.Length] == null)
            {
                /// Placeholder!!!!!!!!!
                equipment[(currentItemIdx + i) % equipment.Length] = item;
                return;
            }

        //else
        dropCurrentItem();
        equipment[currentItemIdx] = item;
    }
#endregion Equipment

#region Armor
    /// TODO
    [System.Serializable]
    public class ArmorPart
    {
        GameObject pickupPrefab;
    }
    public enum EArmorPart
    {
        helmet,
        arms,
        count
    }
    public ArmorPart[] armor = new ArmorPart[(int)EArmorPart.count];
    public void dropArmorPart(EArmorPart part)
    {
        /// Placeholder!!!
        armor[(int)part] = null;
    }
    public void wearArmor(EArmorPart part, ArmorPart a)
    {
        /// Placeholder!!!
        armor[(int)part] = a;
    }

#endregion Armor

    private void LateUpdate()
    {
        /// reset input
        inputRecord[0] = false;
        inputRecord[1] = false;
        inputRecord[2] = false;
        inputRecord[3] = false;


    }
}
