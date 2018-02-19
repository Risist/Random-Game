using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventParticle : MonoBehaviour {

	public ParticleSystem particle;
	public Timer emitCd;
	public int minParticles;
	public float damageScale = 1.0f;
	public float minimumDamage = 0;

	public int minParticlesDeath;
	public float damageScaleDeath = 1.0f;

	private void Start()
	{
		if (!particle)
			particle =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().particleBlood;

	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if (data.damage.toFloat() < minimumDamage && emitCd.isReadyRestart() )
		{
			int n = minParticles + (int)(-data.damage.toFloat() * damageScale);
			particle.transform.position = transform.position;
			particle.transform.rotation = transform.rotation;
			particle.Emit(n);
		}
	}

	void OnDeath(HealthController.DamageData data)
	{
		{
			int n = minParticlesDeath + (int)(-data.damage.toFloat() * damageScaleDeath);
			particle.transform.position = transform.position;
			particle.transform.rotation = transform.rotation;
			particle.Emit(n);
		}
	}
}
