using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowerMany : WeaponSkillAnimation
{
	[System.Serializable]
	public class SpawnStruct
	{
		public GameObject prefab;
		public Transform transform;
	}
	public SpawnStruct[] spawns;
	public Timer shootDelay = new Timer(0);
	public Timer rotationApplyTime = new Timer(0);
	float lastRotation;
	bool shouldShoot = false;
    public bool propagateFraction = true;

    AiPerceiveUnit _instigator;
    AiFraction _fraction;

    public new void Start()
    {
        base.Start();
        _instigator = GetComponentInParent<AiPerceiveUnit>();
        if(propagateFraction)
            _fraction = GetComponentInParent<AiFraction>();
    }

    // Update is called once per frame
    void Update()
	{
        float rot = lastRotation;
        if(movement && isButtonPressed())
            rot = movement.ApplyRotationToMouse();

        if (CastSkill())
        {
            PlayAnimation();
            PlaySound();

            lastRotation = rot;

            rotationApplyTime.restart();
        
            shootDelay.restart();
            shouldShoot = true;
        }



    }

	void LateUpdate()
	{
        if (!rotationApplyTime.isReady())
        {
            movement.ApplyExternalRotation(lastRotation);
        }
        if (shouldShoot && shootDelay.isReady())
		{
            foreach (var it in spawns)
            {
                var objs = Instantiate(it.prefab, it.transform.position, it.transform.rotation).GetComponentsInChildren<DamageOnTriggerSimple>();
                foreach (var itt in objs)
                {
                    itt.instigator = _instigator.gameObject;
                    itt.myFraction = _fraction;
                }
            }
			shouldShoot = false;
		}
	}
}
