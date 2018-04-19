using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSequenceAnimation : WeaponBase {

    public string[] triggerEvents;
    public Animator animManager;
    /// resets animation trigger counter after given time from last ability usage
    public Timer idleReset;
    protected IdleTrigger idle;

    public Timer rotationApplytimer = new Timer(0);
    protected int abilityCounter = 0;
    protected float rotation;


    new protected void Start()
    {
        base.Start();
        idle = GetComponentInParent<IdleTrigger>();
    }

    protected void Update()
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
    protected void LateUpdate()
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
