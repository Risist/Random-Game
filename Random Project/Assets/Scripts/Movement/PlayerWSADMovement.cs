using UnityEngine;
using System.Collections;

/*public class PlayerWSADMovement : MonoBehaviour {

    public MoveController move;


	// Use this for initialization
	void Start () {
        if (move == null)
            move = GetComponent<MoveController>();

        //move.minimalDistance = 0;
	}
	
	// Update is called once per frame
	void Update () {

        
        {
            Vector2 forward = Vector2.up;//move.transform.up;
            Vector2 right = Vector2.right; // move.transform.right;
            Vector2 offset = forward * Input.GetAxis("Vertical") +
                right * Input.GetAxis("Horizontal");
            offset.Normalize(); offset *= move.movementSpeed * Time.deltaTime;

            move.rigidbody.MovePosition(move.rigidbody.position + offset);
        }
	}
}*/
