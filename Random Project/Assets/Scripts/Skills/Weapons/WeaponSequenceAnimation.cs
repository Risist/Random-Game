using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSequenceAnimation : WeaponBase {

    public string[] triggerEvents;
    public Animator animManager;
    /// resets animation trigger counter after given time from last ability usage
    public Timer idleReset;
    IdleTrigger idle;

    public Timer rotationApplytimer = new Timer(0);
    int abilityCounter = 0;
    float rotation;

    new private void Start()
    {
        base.Start();
        idle = GetComponentInParent<IdleTrigger>();
    }

    void Update()
    {
        if (CastSkill())
        {
            PlayAnimation();
            PlaySound();
            if (movement)
            {
                rotation = movement.ApplyRotationToMouse();
                rotationApplytimer.restart();
            }
            abilityCounter = (abilityCounter + 1)%triggerEvents.Length;
            idleReset.restart();
            idle.inactiveTime.restart();
        }
        else if(idleReset.isReadyRestart())
        {
            abilityCounter = 0;
        }
    }
    private void LateUpdate()
    {
        if (!rotationApplytimer.isReady())
        {
            movement.ApplyExternalRotation(rotation);
        }
    }

    protected void PlayAnimation()
    {
        if (animManager)
            animManager.SetTrigger(triggerEvents[abilityCounter]);
    }
}
