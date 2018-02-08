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
			particle = GetComponent<ParticleSystem>();
	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if (data.damage.toFloat() < minimumDamage && emitCd.isReadyRestart() )
		{
			particle.Emit(minParticles + (int)(-data.damage.toFloat() * damageScale) );
		}
	}

	void OnDeath(HealthController.DamageData data)
	{
		{
			particle.Emit(minParticlesDeath + (int)(-data.damage.toFloat() * damageScaleDeath));
		}
	}
}
