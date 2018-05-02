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
    public int playerId = 1;

    public void setPad(bool s)
    {
        if (pad == s)
            return;

        pad = s;

        var progressionManager = GetComponent<ProgressionManager>();
        if (s)
        {
            xAxisCode += "_pad" + playerId;
            yAxisCode += "_pad" + playerId;
            xControlAxisCode += "_pad" + playerId;
            yControlAxisCode += "_pad" + playerId;

            foreach(var it in progressionManager.slots)
            {
                it.keyCode = "_pad" + playerId;
                it.skillObject.buttonCode = it.keyCode;
            }
        }
        else
        {
            int length  = ("_pad" + playerId).Length;

            xAxisCode = xAxisCode.Substring(0, xAxisCode.Length - length);
            yAxisCode = yAxisCode.Substring(0, yAxisCode.Length - length);
            xControlAxisCode = xControlAxisCode.Substring(0, xControlAxisCode.Length - length);
            yControlAxisCode = yControlAxisCode.Substring(0, yControlAxisCode.Length - length);

            foreach (var it in progressionManager.slots)
            {
                it.keyCode = it.keyCode.Substring(0, it.keyCode.Length - length);
                it.skillObject.buttonCode = it.keyCode;
            }
        }
    }

    bool atMove = false;
    bool blockMovement = false;

    // Use this for initialization
    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();

        if (pad)
        {
            xAxisCode += "_pad" + playerId;
            yAxisCode += "_pad" + playerId;
            xControlAxisCode += "_pad" + playerId;
            yControlAxisCode += "_pad" + playerId;
        }
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

            if (newInput.sqrMagnitude > 0.35)
            {
                lastInput = newInput;

                body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
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

        if (rotateToDirection)
        {
            if (pad && !atMove)
            {
                Vector2 newInput = new Vector2(Input.GetAxis(xControlAxisCode), Input.GetAxis(yControlAxisCode));

                if (newInput.sqrMagnitude > 0.35)
                {
                    lastInput = newInput;
                }
            }
            else if (appliedExternalRotation)
            {
                appliedExternalRotation = false;
                return;
            }
            body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
        }
        appliedExternalRotation = false;

	}

	// Update is called once per frame
	void FixedUpdate()
    {
        if (!enabled)
            return;

        Vector2 input = new Vector2(Input.GetAxisRaw(xAxisCode), Input.GetAxisRaw(yAxisCode));
        atMove = (input.x != 0 || input.y != 0) && !appliedExternalRotation;
        if (atMove)
        {
            lastInput = input.normalized;
            body.AddForce(input * movementSpeed * Time.fixedDeltaTime);
        }
    }
}