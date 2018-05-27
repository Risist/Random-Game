using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Plays animation and after given delay spawns provided prefab
 * Applies rotation to mouse after casting skill
 * Animation should then turn off PlayerMovement by it's own
 */
public class WeaponThrowerFreeze : WeaponSkillAnimation
{
    public GameObject prefab;
    public Timer shootDelay = new Timer(0);
    public Timer rotationApplyTime = new Timer(0);
    protected bool shouldShoot = false;
    public bool propagateFraction = true;

    protected AiPerceiveUnit _instigator;
    protected AiFraction _fraction;

    protected Transform _transform;
    float rotation;

    new void Start () {
        base.Start();
        _transform = transform;
        //rotationApplyTime.actualTime += 10000000000000000000;


        _instigator = GetComponentInParent<AiPerceiveUnit>();
        if(propagateFraction)
            _fraction = GetComponentInParent<AiFraction>();
    }
	
	void Update () {

		if(CastSkill())
        {
            PlayAnimation();
            PlaySound();

            if (movement)
            {
                rotation = movement.ApplyRotationToMouse();
                rotationApplyTime.restart();
            }

            shootDelay.restart();
            shouldShoot = true;
        }

        
    }
    protected void LateUpdate()
    {
        if (!rotationApplyTime.isReady())
        {
            movement.ApplyExternalRotation(rotation);
        }

        if (shouldShoot)
        {
            if (shootDelay.isReady())
            {
                var objs = Instantiate(prefab, _transform.position, _transform.rotation).GetComponentsInChildren<DamageOnTriggerSimple>();
                foreach (var it in objs)
                {
                    it.instigator = _instigator.gameObject;
                    it.myFraction = _fraction;
                }
                shouldShoot = false;
            }
            else
            {
                if (movement)
                    movement.ApplyExternalRotation(rotation);
            }
        }
    }
}
