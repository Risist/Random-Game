using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2 : MonoBehaviour {

    public float movementSpeed = 1.0f;
    Rigidbody2D body;

    bool atMove = false;
    public bool rotateExternalToDirection = true;
    public bool rotateToDirection = true;
    public bool moveToDirection = true;

    /// used to determine direction to which the character should be rotated to 
    Vector2 lastInput;
    /// if external rotation were applied we should not change rotation to direction of move
    bool appliedExternalRotation;

    public RideCthuluController rideController;
    [Range(0.0f, 1.0f)]
    public float rideFactor;


    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();

    }


    public void ApplyForce(Vector2 force)
    {
        if (body && moveToDirection)
            body.AddForce(force);
    }
    public void ApplyForceToMouse(float force)
    {
        if (body && moveToDirection)
        {
            Vector2 v = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - body.position;
            body.AddForce(v.normalized * force * Time.fixedDeltaTime);
        }
    }
    public float ApplyExternalRotation(Vector2 newInput)
    {
        appliedExternalRotation = true;
        lastInput = newInput;

        var rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);

        if (rotateExternalToDirection)
            transform.rotation = Quaternion.Euler(0, 0, rotation);

        return rotation;
    }
    public float ApplyExternalRotation(float newRotation)
    {
        appliedExternalRotation = true;

        if (rotateExternalToDirection)
            lastInput = (transform.rotation = Quaternion.Euler(0, 0, newRotation)) * Vector2.up;
        else
            lastInput = Quaternion.Euler(0, 0, newRotation) * Vector2.up;

        return body.rotation = newRotation;
    }
    /*public float ApplyRotationToMouse()
    {
        if (pad)
        {
            Vector2 newInput = new Vector2(Input.GetAxis(xControlAxisCode), Input.GetAxis(yControlAxisCode));

            if (newInput.sqrMagnitude > 0.35)
            {
                lastInput = newInput;
                appliedExternalRotation = true;

                if (rotateExternalToDirection)
                    body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
            }

            return body.rotation;
        }
        else
        {
            Vector2 newInput = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

            lastInput = newInput;
            appliedExternalRotation = true;

            var rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
            if (rotateExternalToDirection)
                body.rotation = rotation;
            return rotation;
        }

    }*/

    public bool wereExternalRotationApplied() { return appliedExternalRotation; }


    private void LateUpdate()
    {
        if (!enabled)
            return;

        /// rotate toDirection stuff
        /*if (rotateToDirection)
        {
            if (pad && !atMove)
            {
                Vector2 newInput = new Vector2(Input.GetAxis(xControlAxisCode), Input.GetAxis(yControlAxisCode));

                if (newInput.sqrMagnitude > 0.35)
                    lastInput = newInput;
            }
            else if (!appliedExternalRotation)
                body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
        }
        appliedExternalRotation = false;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enabled)
            return;

        /*Vector2 input = new Vector2(Input.GetAxisRaw(xAxisCode), Input.GetAxisRaw(yAxisCode));
        atMove = (input.x != 0 || input.y != 0) && !appliedExternalRotation;

        if (atMove)
        {
            lastInput = input.normalized;
            if (moveToDirection)
                body.AddForce(input * movementSpeed * Time.fixedDeltaTime);

            if (rideController)
            {
                Debug.Log(lastInput);
                rideController.selectTargetOffset(lastInput * 1000, rideFactor);
            }
        }*/
    }
}
