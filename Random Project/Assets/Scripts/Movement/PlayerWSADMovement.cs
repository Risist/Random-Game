using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerWSADMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public Rigidbody2D body;
    
    // Use this for initialization
    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
    }

    Vector2 lastInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.x != 0 || input.y != 0)
            lastInput = input;
        body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
        
        body.AddForce(input * movementSpeed * Time.fixedDeltaTime);
    }
}