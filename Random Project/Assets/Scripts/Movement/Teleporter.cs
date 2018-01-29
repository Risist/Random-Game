using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Teleporter : MonoBehaviour {

	public string teleporterName;
	public Teleporter other;
	public Timer liveTime;
	TeleportRoom room;

	Timer deathTimer = new Timer();
	Animator animator;
	int teleportHashId;
	int removeHashId;
	public bool remove = false;

	private void Start()
	{
		other = this;

		room = GameObject.Find(teleporterName).GetComponent<TeleportRoom>();
		if (room)
			room.AddTeleporter(this);
		else
			Debug.Log("teleport init failed");

		animator = GetComponent<Animator>();
		teleportHashId = Animator.StringToHash("StartAnim");
		removeHashId = Animator.StringToHash("remove");

		liveTime.restart();
		deathTimer.restart();
		deathTimer.cd = liveTime.cd + 1;
	}

	private void Update()
	{
		if (liveTime.isReadyRestart() && animator)
			animator.SetTrigger(removeHashId);
		if (deathTimer.isReadyRestart() && remove)
			Destroy(gameObject);
	}
	private void OnDestroy()
	{
		if(room)
			room.RemoveTeleporter(this);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

		if (room && rb && room.tpCd.isReadyRestart() )
		{
			rb.MovePosition( other.transform.position );
			if(animator)
				animator.SetTrigger(teleportHashId);
		}
	}
}
