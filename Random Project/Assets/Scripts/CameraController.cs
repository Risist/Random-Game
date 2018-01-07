using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

	[Range(0.0f,10.0f)]
	public float learpFactor = 10.0f;
    Vector3 initialOffsetPosition;
	float initialOffsetRotation;
	float initialOffsetScale;


	// Use this for initialization
	void Start()
    {
        initialOffsetPosition = transform.position - player.transform.position;
		initialOffsetRotation = transform.rotation.eulerAngles.z;
		initialOffsetScale = Camera.main.orthographicSize;
	}

    // Update is called once per frame
    void LateUpdate()
    {
		if (player)
		{
			transform.position = transform.position + (player.transform.position - transform.position) * learpFactor * Time.deltaTime
				+ initialOffsetPosition + (Vector3)shakePositionInfluence;
		}

		transform.rotation = Quaternion.Euler(0, 0, initialOffsetRotation + shakeRotationInfluence);
		Camera.main.orthographicSize = initialOffsetScale + shakeScaleInfluence;
	}
	private void FixedUpdate()
	{
		shakePositionInfluence *= shakePositionDamping;
		shakeRotationInfluence *= shakeRotationDamping;
		shakeScaleInfluence *= shakeScaleDamping;
	}


	/// Screan shakes
	/// 
	[Range(0.0f, 1.0f)]
	public float shakePositionDamping;
	Vector2 shakePositionInfluence;
	public void shakePosition(Vector2 shakePower)
	{
		shakePositionInfluence += shakePower;
	}

	[Range(0.0f, 1.0f)]
	public float shakeRotationDamping;
	float shakeRotationInfluence;
	public void shakeRotation(float shakePower)
	{
		shakeRotationInfluence += shakePower;
	}

	[Range(0.0f, 1.0f)]
	public float shakeScaleDamping;
	float shakeScaleInfluence;
	public void shakeScale(float shakePower)
	{
		shakeScaleInfluence += shakePower;
	}


}

