using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public GameObject player2;
    public float multiScaleFactor = 0.0f;
    public float multiOldFactor = 1.0f;
    public float multiScaleLerpFactor = 1.0f;

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
        float offsetScale = initialOffsetScale + shakeScaleInfluence;

        if (player)
		{
            Vector3 middlePos = player.transform.position;
            if (player2)
            {
                middlePos = (middlePos + player2.transform.position) * 0.5f;
                offsetScale = Mathf.Lerp(Camera.main.orthographicSize, 
                    Mathf.Clamp(initialOffsetScale * multiOldFactor + (player.transform.position - player2.transform.position).magnitude * multiScaleFactor,
                                initialOffsetScale, float.PositiveInfinity) 
                            + shakeScaleInfluence
                        , multiScaleLerpFactor);
            }


            transform.position = transform.position + ( middlePos - transform.position) * learpFactor * Time.deltaTime
				+ (Vector3)shakePositionInfluence;
			transform.position = new Vector3(transform.position.x, transform.position.y, initialOffsetPosition.z);

            
		}else if(player2)
        {
            transform.position = transform.position + (player2.transform.position - transform.position) * learpFactor * Time.deltaTime
                + (Vector3)shakePositionInfluence;
            transform.position = new Vector3(transform.position.x, transform.position.y, initialOffsetPosition.z);
        }

		transform.rotation = Quaternion.Euler(0, 0, initialOffsetRotation + shakeRotationInfluence);
		Camera.main.orthographicSize = offsetScale;
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
        if(!player2)
		    shakePositionInfluence += shakePower;
	}

	[Range(0.0f, 1.0f)]
	public float shakeRotationDamping;
	float shakeRotationInfluence;
	public void shakeRotation(float shakePower)
	{
        if (!player2)
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

