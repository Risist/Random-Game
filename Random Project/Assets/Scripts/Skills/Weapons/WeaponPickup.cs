using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

    public int id;
    public GameObject objectToRemove;
    public bool spawnOld = true;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var manager = other.GetComponent<WeaponManager>();
        if (manager && manager.tNextPickup.isReadyRestart() )
        {
            int curr = manager.current;
            manager.setWeapon(id);
            if(spawnOld && curr >= 0 && manager.weapons[curr].pickupPrefab)
                Instantiate(manager.weapons[curr].pickupPrefab, transform.position, transform.rotation);
            if(objectToRemove)
                Destroy(objectToRemove);
        }
    }
}
