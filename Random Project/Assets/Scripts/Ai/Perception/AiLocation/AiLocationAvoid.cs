using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationAvoid : AiLocationBase {

    public Timer tRecalculate;
    public string typeName;

    Vector2 holdedInfluence = Vector2.zero;
    public float scale = 1;

    public override Vector2 GetLocation()
    {
        if(tRecalculate.isReadyRestart())
        {
            holdedInfluence = Vector2.zero;
            Vector2 myPos = mind.transform.position;
            
            foreach (var it in mind.myPerception.memory)
                if (it.unit.type == typeName)
                {
                    Vector2 toAim = myPos - (Vector2)it.unit.transform.position;
                    holdedInfluence += toAim / toAim.sqrMagnitude;
                }
        }

        return holdedInfluence * scale;
    }
}
