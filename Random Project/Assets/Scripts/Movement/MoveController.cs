using UnityEngine;
using System.Collections;


/*public class MoveController : MonoBehaviour {

    public new Rigidbody2D rigidbody;

    [System.NonSerialized] // point where the object will move
    public Vector2 destination;
    //[System.NonSerialized] // check wheder the object is on move
    public bool arrived = true;

    public void SetDestination( Vector2 newDestination)
    {
        arrived = false;
        destination = newDestination;
        if(IsInMinimalDistance() == false)
            RotateToDestination();
    }

    // how fast will the object move towards destination
    public float movementSpeed;
    // how close the object will try to move to destination
    public float minimalDistance;
    public bool IsInMinimalDistance()
    {
        return (rigidbody.position - destination).sqrMagnitude < minimalDistance * minimalDistance;
    }
    public void RotateToDestination()
    {

        float angleRad = Mathf.Atan2(destination.y - rigidbody.position.y, destination.x - rigidbody.position.x);
        rigidbody.MoveRotation( (180 / Mathf.PI) * angleRad + 90);

        //rigidbody.MoveRotation( Vector2.Angle(rigidbody.position, destination) );
    }
    public void RotateToDestinationInstant(Vector2 destination)
    {
        float angleRad = Mathf.Atan2(destination.y - rigidbody.position.y, destination.x - rigidbody.position.x);
        rigidbody.transform.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * angleRad + 90);
    }
    public void MoveForward()
    {
        Vector2 up = transform.up;
        //rigidbody.MovePosition(rigidbody.position - up* movementSpeed * Time.deltaTime );
        rigidbody.AddForce(up * movementSpeed * Time.deltaTime);
    }


    // how often is the rotation towards destination updated
    public Timer reactionTime;



	// Use this for initialization
	void Start () {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(arrived == false)
        {
            if (IsInMinimalDistance() )
            {
                arrived = true;
                reactionTime.restart();
            }
            else
            {
                if(reactionTime.isReadyRestart())
                    RotateToDestination();
                MoveForward();
            }
        }
	}
}*/
