using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSequenceMovement : WeaponSequenceAnimation {

    public Timer tMovementApplay;
    public float movementSpeed;

	// Use this for initialization
	new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update ()
    {
        if (CastSkill())
        {
            PlayAnimation();
            PlaySound();
            if (movement)
            {
                //rotation = movement.ApplyRotationToMouse();
                //rotationApplytimer.restart();
                tMovementApplay.restart();
            }
            abilityCounter = (abilityCounter + 1) % triggerEvents.Length;
            idleReset.restart();
            idle.inactiveTime.restart();
        }
        else if (idleReset.isReadyRestart())
        {
            abilityCounter = 0;
        }
    }
    protected new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!tMovementApplay.isReady())
        {
            movement.ApplyForceToMouse(movementSpeed);
        }
    }
}
