﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * performs set of behaviours at once
 * stops performance when one of behaviours returns end
 */
public class AiBehaviourCompositeTogether : AiBehaviourBase {

	[System.NonSerialized]
	public AiBehaviourBase[] behaviours;

	// Use this for initialization
	new void Start () {
		base.Start();
		behaviours = GetComponents<AiBehaviourBase>();
	}


	public override void EnterAction()
	{
		base.EnterAction();
		foreach (var it in behaviours)
			if(it != this)
				it.EnterAction();
	}
	public override void ExitAction()
	{
		base.ExitAction();
		foreach (var it in behaviours)
			if (it != this)
				it.ExitAction();
	}
	public override bool PerformAction()
	{
		bool b = true;
        bool terminate = false;

		foreach (var it in behaviours)
			if (it != this)
			{
				b = it.PerformAction() && b;
                terminate = terminate || it.Treminate();
			}
		return b || terminate;
	}

	public override bool CanEnter()
	{
		bool b = base.CanEnter();
		foreach (var it in behaviours)
			if (it != this)
				b = b && it.CanEnter();
		return b;
	}

    public override bool Treminate()
    {
        bool b = false;
        foreach (var it in behaviours)
            if (it != this)
                b = b || it.Treminate();
        return b;
    }
}
