using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventTree : MonoBehaviour
{
    public bool active = true;

    public void OnDeath(HealthController.DamageData data)
    {
        if (!active)
        {
            return;
        }
        ChangeParent();
        AddComponent();
    }

    private void ChangeParent()
    {
        GameObject oldParent = gameObject.transform.parent.gameObject;
        GameObject go = new GameObject();
        go.transform.position = gameObject.transform.position;
        gameObject.transform.SetParent(go.transform, false);
        Destroy(oldParent);
    }

    private void AddComponent()
    {
        gameObject.AddComponent<BoxCollider2D>();
        HealthController hc = gameObject.AddComponent<HealthController>();
        hc.actual = 1000;
        hc.max = 2000;
        hc.removeAfterDeath = true;
        hc.objectToRemove = null;
        AiPerceiveUnit ai = gameObject.AddComponent<AiPerceiveUnit>();
        ai.health = hc;
    }
}