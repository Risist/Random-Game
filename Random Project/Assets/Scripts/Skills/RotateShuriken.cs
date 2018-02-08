using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShuriken : MonoBehaviour
{

    public float rotationSpeed = 10;


	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
