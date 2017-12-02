using System;
using System.Collections.Generic;
using UnityEngine;

abstract class BehaviourBase : MonoBehaviour
{
    /// called when the behaviour is choosen to be executed
	/// there should go all initialisation code
    public virtual void OnStart() {}
	/// executes the behaviour;
	/// @return - has execution of the behaviour ended up?
    public abstract bool OnExecute();
	/// called when behaviour ends its execution
	/// there should go all clean up code
    public virtual void OnExit() { }
	/// tells the system how good is the behaviour in the current context
    public virtual float GetUtility() { return 1.0f; }


    /// to be used by AiMind only
    public void SetOwner(AiMind s) { owner = s; }

    protected AiMind owner;
}
