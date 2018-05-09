using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeaponMarker : MonoBehaviour
{
    public string attachType;
    public GameObject attachObject;
    [SerializeField]
    private Timer activeTime;
    public bool triggerIdle = true;

    public void activateMark()
    {
        activeTime.restart();
        attachObject.SetActive(true);
        if (triggerIdle)
        {
            var c = GetComponentInParent<IdleTrigger>();
            if (c)//&& !activeTime.isReady(activeTime.cd - c.inactiveTime.cd) )
                c.inactiveTime.restart();
        }
    }

    public void Update()
    {
        

        if (attachObject.activeInHierarchy)
        {
            if (activeTime.isReady())
            {
                //activeTime.restart();
                attachObject.SetActive(false);
            }
            else if (triggerIdle )
            {
                var c = GetComponentInParent<IdleTrigger>();
                if (c )//&& !activeTime.isReady(activeTime.cd - c.inactiveTime.cd) )
                    c.inactiveTime.restart();
            }
        }



    }
}
