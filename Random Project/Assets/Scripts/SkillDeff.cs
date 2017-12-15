using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDeff : MonoBehaviour {

    public float rotationSpeed  = 10;

	// Use this for initialization
	void Start ()
    {
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed * Time.deltaTime);	
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            Destroy(gameObject);
        }
    }
}
