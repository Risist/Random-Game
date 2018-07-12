using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourGrab : AiBehaviourBase {

    public float pullFractor;
    public float pullDistance;
    public float breakDistance;
    bool onPerform = false;
    public Rigidbody2D connectedBody;
    public Transform myTransform;

    new private void Start()
    {
        if(!myTransform)
            myTransform = GetComponentInParent<Rigidbody2D>().transform;
    }

    public override bool PerformAction()
    {
        onPerform = true;
        return true;
    }

    public override void ExitAction()
    {
        base.ExitAction();
        onPerform = false;
    }
    public override void EnterAction()
    {
        onPerform = true;
        base.EnterAction();
    }
    public override bool CanEnter()
    {
        return !connectedBody;
    }

    private void FixedUpdate()
    {
        if(connectedBody)
        {
            Vector2 toMy = (Vector2)myTransform.position - connectedBody.position;
            if(toMy.sqrMagnitude > pullDistance*pullDistance)
                connectedBody.AddForce(toMy * pullFractor);
            if (toMy.sqrMagnitude > breakDistance * breakDistance)
                connectedBody = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!onPerform)
            return;

        Debug.Log("OnPerform");
        var b = collision.GetComponentInParent<Rigidbody2D>();
        if (!connectedBody && b)
        {
            connectedBody = b;

            Debug.Log("OnPerform - found body");
        }
    }

}
