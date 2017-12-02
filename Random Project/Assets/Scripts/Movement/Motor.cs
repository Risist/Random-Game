using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    public float movementSpeed;
    public float movementSpeedFall;


    // Use this for initialization
    void Start()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementSpeed -= movementSpeedFall * Time.fixedDeltaTime;
        movementSpeed = Mathf.Clamp(movementSpeed, 0, float.MaxValue);
        
        rigidbody.AddForce(
            new Vector2(transform.up.x, transform.up.y)
            * movementSpeed * Time.fixedDeltaTime
        );
    }

}