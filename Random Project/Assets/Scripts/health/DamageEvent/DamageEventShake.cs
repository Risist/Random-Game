using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventShake : MonoBehaviour {

	public float shakePositionBase = 0.0f;
	public float shakePositionDamage = 1.0f;

	public float shakeRotationBase = 0.0f;
	public float shakeRotationDamage = 1.0f;

	public float shakeScaleBase = 0.0f;
	public float shakeScaleDamage = 1.0f;

	///
	public float shakePositionBaseDeath = 0.0f;
	public float shakePositionDamageDeath = 0.0f;

	public float shakeRotationBaseDeath = 0.0f;
	public float shakeRotationDamageDeath = 0.0f;

	public float shakeScaleBaseDeath = 0.0f;
	public float shakeScaleDamageDeath = 0.0f;

	CameraController controller;

	float lastDamage = 0;

	// Use this for initialization
	void Start () {
		controller = Camera.main.GetComponent<CameraController>();
	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if (data.damage.toFloat() < 0)
		{
			controller.shakePosition(	Random.insideUnitCircle.normalized	* (shakePositionDamage + shakePositionDamage	* data.damage.toFloat()));
			controller.shakeRotation(	Random.Range(-1, 1)					* (shakeRotationDamage + shakeRotationDamage	* data.damage.toFloat()));
			controller.shakeScale(		Random.Range(-1, 1)					* (shakeScaleDamage	+ shakeScaleDamage		* data.damage.toFloat()));

			lastDamage = data.damage.toFloat();
		}
	}

	void OnDeath(HealthController.DamageData data)
	{
		if (data.damage.toFloat() < 0)
		{
			lastDamage = data.damage.toFloat();

			controller.shakePosition(Random.insideUnitCircle.normalized * (shakePositionDamageDeath + shakePositionDamageDeath * lastDamage));
			controller.shakeRotation(Random.Range(-1, 1) * (shakeRotationDamage + shakeRotationDamageDeath * lastDamage));
			controller.shakeScale(Random.Range(-1, 1) * (shakeScaleDamageDeath + shakeScaleDamageDeath * lastDamage));
		}
	}

	private void OnDestroy()
	{
		controller.shakePosition(Random.insideUnitCircle.normalized * (shakePositionDamageDeath + shakePositionDamageDeath * lastDamage));
		controller.shakeRotation(Random.Range(-1, 1) * (shakeRotationDamage + shakeRotationDamageDeath *lastDamage));
		controller.shakeScale(Random.Range(-1, 1) * (shakeScaleDamageDeath + shakeScaleDamageDeath * lastDamage));
	}
}
