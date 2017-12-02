using UnityEngine;
using System.Collections;

public class DamageOnTriggerSimple : DamageOnTrigger {

    public SimpleDamage damageEnter;
    public SimpleDamage damageStay;
    public SimpleDamage damageExit;

    // Use this for initialization
    void Start () {
        _damageEnter = damageEnter;
        _damageStay = damageStay;
        _damageExit = damageExit;
    }
}
