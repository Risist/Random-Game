using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	[System.Serializable]
    public struct WeaponSet
    {
        // skills are binded in order of slots
        public string name;
        public WeaponBase[] skills;
        public GameObject pickupPrefab;
    }
    public WeaponSet[] weapons;
    public int current;

    public Timer tNextPickup;

    ProgressionManager manager;

    private void Start()
    {
        manager = GetComponent<ProgressionManager>();
        if (current >= 0)
            setWeapon(current);
    }

    public void setWeapon(int id)
    {
        current = id;
        for( int i = 0; i < weapons[id].skills.Length; ++i)
        {
            manager.BindToSlot(weapons[id].skills[i],manager.slots[i]);
            //manager.assignmentPanel.SetSkill(i, weapons[id].skills[i]);
            manager.skillPanel.SetSkill(i, weapons[id].skills[i]);
        }
    }
}
