using UnityEngine;
using System.Collections;


/// TO REFRACTOR OR REMOVE
/*public class RandomMovement : MonoBehaviour {

    public MoveController move;

    public float cdChangeDestinationMin = 0.1f;
    public float cdChangeDestinationMax = 1.0f;
    Timer timeChange = new Timer();

    public float minimalDistance;
    public float maximalDistance;
    public bool offsetFromActual = false;

    // Use this for initialization
    void Start () {
        if (move == null)
            move = GetComponent<MoveController>();

	}
	
	// Update is called once per frame
	void Update () {

        if(timeChange.isReadyRestart())
        {
            timeChange.cd = Random.Range(cdChangeDestinationMin, cdChangeDestinationMax);

            Vector2 offset = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(minimalDistance, maximalDistance), 0);
            if (offsetFromActual)
                move.SetDestination( move.destination + offset);
            else
                move.SetDestination( new Vector2(transform.position.x, transform.position.y) + offset);

        }
	}
}*/
