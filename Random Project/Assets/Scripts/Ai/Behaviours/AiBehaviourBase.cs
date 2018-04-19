using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBehaviourBase : MonoBehaviour
{
	[System.NonSerialized]
	public AiUnitMind myMind;
	protected void Start()
	{
		myMind = GetComponentInParent<AiUnitMind>();
	}
	
#region Propagate
	public AiBehaviourBase nextBehaviour;
#endregion Propagate


#region Virtual
	/// Called every frame after selecting the behaviour to be executed.
	/// <returns> has the action ended performance? </returns>
	public virtual bool PerformAction() { return true; }

	/// Called upon selecting the behaviour. All state initialisation code goes here
	public virtual void ExitAction()
	{
	}
	/// Called upon selecting the behaviour. All state initialisation code goes here
	public virtual void EnterAction()
	{
	}

    ///decides if whole composite is ready to be played out
	public virtual bool CanEnter()
	{
		return true;
	}

    /// allows behaviour to terminate execution of whole Composite
    public virtual bool Treminate()
    {
        return false;
    }
#endregion Virtual

}
