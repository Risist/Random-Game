using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRoom : MonoBehaviour {

	List<Teleporter> teleporters = new List<Teleporter>();
	public Timer changeTeleportsCd;
	public Timer tpCd;

	private void Update()
	{
		if(changeTeleportsCd.isReadyRestart())
			SetTeleports();
	}

	void SetTeleports()
	{
		foreach (var it in teleporters)
			it.other = getRandomTeleporter(it);
	}

	public void AddTeleporter(Teleporter s)
	{
		teleporters.Add(s);
	}
	public void RemoveTeleporter(Teleporter s)
	{
		teleporters.Remove(s);
	}

	public Teleporter getRandomTeleporter(Teleporter my)
	{
		if (teleporters.Count > 1)
		{
			int tpId = Random.Range(0, teleporters.Count);
			while (teleporters[tpId] == my)
				tpId = Random.Range(0, teleporters.Count);
			return teleporters[tpId];
		}
		return my;
	}
}
