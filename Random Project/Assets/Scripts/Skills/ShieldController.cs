using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    public GameObject player;
	public float rotationSpeedMin;
	public float rotationSpeedMax;
	float rotationSpeed = 10;
    private Vector3 offset;         

    public void linkToPlayer(GameObject _player)
    {
        player = _player;
        transform.position = player.transform.position;
        offset = transform.position - player.transform.position;
    }

    // Use this for initialization
    void Start()
    {
		rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward , rotationSpeed * Time.deltaTime);
    }
        // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player)
            transform.position = player.transform.position + offset;
        else
            Destroy(gameObject);
    }
}
