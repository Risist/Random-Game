using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public Rigidbody2D body;
	public bool rotateToDirection = true;
    public string xAxisCode = "Horizontal";
    public string yAxisCode = "Vertical";

    public string xControlAxisCode = "Horizontal2";
    public string yControlAxisCode = "Vertical2";
    public bool pad = false;

    // Use this for initialization
    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
    }

    public void ApplyForce(Vector2 force)
    {
        body.AddForce(force);
    }
    public void ApplyForceToMouse(float force)
    {
        Vector2 v = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - body.position;
        body.AddForce(v.normalized * force*Time.fixedDeltaTime);
    }
    public float ApplyExternalRotation(Vector2 newInput)
	{
		appliedExternalRotation = true;
		lastInput = newInput;

		var rotation = body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
		transform.rotation = Quaternion.Euler(0, 0, body.rotation);

		return rotation;
	}
	public float ApplyExternalRotation(float newRotation)
	{
		appliedExternalRotation = true;
		lastInput = ( transform.rotation = Quaternion.Euler(0, 0, newRotation) ) * Vector2.up;
        
		return body.rotation = newRotation;
	}

	public float ApplyRotationToMouse()
	{
        if (pad)
        {
            Vector2 newInput = new Vector2(Input.GetAxis(xControlAxisCode), Input.GetAxis(yControlAxisCode));

            if (newInput.sqrMagnitude > 0.1)
            {
                lastInput = newInput;

                body.rotation = Vector2.Angle(Vector2.up, -lastInput) * (lastInput.x > 0 ? -1 : 1);
            }

            return body.rotation;
        }
        else
        {
            Vector2 newInput = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            
            lastInput = newInput;
            appliedExternalRotation = true;
            return body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
        }
       
    }

	bool appliedExternalRotation;
    Vector2 lastInput;

	private void LateUpdate()
	{
        if (!enabled)
            return;

		if (rotateToDirection && !appliedExternalRotation)
		{
			body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
		}
		appliedExternalRotation = false;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        if (!enabled)
            return;

        Vector2 input = new Vector2(Input.GetAxisRaw(xAxisCode), Input.GetAxisRaw(yAxisCode)).normalized;
        if ( (input.x != 0 || input.y != 0) && !appliedExternalRotation )
            lastInput = input;

		body.AddForce(input * movementSpeed * Time.fixedDeltaTime);
    }
}