using UnityEngine;
using System.Collections;   
using System.Collections.Generic;

/// WIP

/// rewrited system from ReEngine to c# https://github.com/Risist/ReEngine2Die/tree/master/ReEngine/ReEngine/Re/Ai/Mind
/// 
public class AiMind : MonoBehaviour
{
    #region Events
    // Use this for initialization
	void Start () 
    {
        chance.chances = new float[5];
	}
	
	// Update is called once per frame
	void Update () {
        if (actualBehaviour == null||
            /// execute behaviour
            actualBehaviour.OnExecute())
        /// set up new behaviour 
        {
            if (actualBehaviour != null)
                actualBehaviour.OnExit();

            /// fill chances vector
            //assert(behaviours.size() == chance.chances.size());
            //size_t size = behaviours.size();
            //Utility_t helperValue;

            if (chance.chances.Length < behaviours.Count)
            {
                chance.chances = new float[behaviours.Count];
            }

            for (int i = 0; i < behaviours.Count; ++i)
            {
                float helperValue = behaviours[i].GetUtility();
                chance.chances[i] = helperValue > treshold ? helperValue : 0;
            }

            /// choose new behaviour
            int id = chance.GetRandedId();
            actualBehaviour = behaviours[id];
            actualBehaviour.OnStart();

            /// update memory
            behaviourMemory[4] = behaviourMemory[3];
            behaviourMemory[3] = behaviourMemory[2];
            behaviourMemory[2] = behaviourMemory[1];
            behaviourMemory[1] = behaviourMemory[0];
            behaviourMemory[0] = actualBehaviour;
        }
	}
    #endregion

    #region Creation and behaviour managament
    void AddBehaviour(BehaviourBase s)
    {
        behaviours.Add(s);
        s.SetOwner(this);
    }
    void SetBehaviour(BehaviourBase s)
    {
        if (actualBehaviour != null)
            actualBehaviour.OnExit();
        actualBehaviour = s;
        actualBehaviour.OnStart();

        /// update memory
        behaviourMemory[4] = behaviourMemory[3];
        behaviourMemory[3] = behaviourMemory[2];
        behaviourMemory[2] = behaviourMemory[1];
        behaviourMemory[1] = behaviourMemory[0];
        behaviourMemory[0] = actualBehaviour;
    }
    void SetBehaviour(int id)
    {
        SetBehaviour(behaviours[id]);
    }
    void setNewBehaviour(BehaviourBase s)
    {
        AddBehaviour(s);
        SetBehaviour(s);
    }
    #endregion


    #region Behaviour and random data
    List<BehaviourBase> behaviours = new List<BehaviourBase>();
    RandomChance chance;
    
    /// actually executed behaviour, if equal to nullptr no behaviour is being execued
    BehaviourBase actualBehaviour;
    /// allows to sign how big utility has to be to consider 
    /// a behaviour to choose as actual executed;
    /// each behaviour with utility less than treshold has 0 probability of being choosen
    public float treshold;
    #endregion

    #region Memory
    /// @param:pastTime - how many behaviours in past to go
    /// @return - a behaviour which was executed @pastTime cycles ago
    BehaviourBase getFromMemory(int pastTime)
    {
        return behaviourMemory[pastTime];
    }

    static public int getMemorySize(){ return 5; }
	BehaviourBase[] behaviourMemory = new BehaviourBase[5];
    #endregion
}
