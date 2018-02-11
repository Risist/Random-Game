using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Detects fraction objects.
 * Not designed to detect obstacles, only aims of attack, follow, cast spells ect
 */
public class AiPerception : MonoBehaviour {

	public Timer timerPerformSearch;
	/// how far the field of view goes
	public float searchDistance = 5.0f;
	/// how many rays to shoot each search
	public int nRays = 5;
	/// radius of search cone the rays will be shooted from
	public float coneRadius = 100.0f;
	/// how long the target is remembered
	public float memoryTime = 5.0f;

	public class MemoryItem
	{
		public Timer remainedTime;
		public AiFraction fraction;
		public float lastDistance;
	}
	[System.NonSerialized]
	public List<MemoryItem> memory = new List<MemoryItem>();

	// Update is called once per frame
	void Update ()
	{
		if(timerPerformSearch.isReadyRestart())
		{
			PerformClear();
			PerformSearch();
		}
	}

	void PerformSearch()
	{
		float angleOffset = coneRadius / nRays;

		for (int i = 0; i < nRays; ++i)
		{
			var rays = Physics2D.RaycastAll(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i) * transform.up, searchDistance);
			Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i) * transform.up * searchDistance, Color.green, 0.25f);

			foreach (var it in rays)
			{
				var f = it.collider.GetComponent<AiFraction>();
				if(f)
				{
					bool bFound = false;
					foreach(var itMemory in memory)
						if(itMemory.fraction == f)
						{
							itMemory.remainedTime.restart();
							itMemory.lastDistance = it.distance;
							bFound = true;
							break;
						}
					if(!bFound)
					{
						var memoryItem = new MemoryItem();
						memoryItem.fraction = f;
						memoryItem.remainedTime = new Timer(memoryTime);
						memoryItem.lastDistance = it.distance;

						memory.Add(memoryItem);
					}
				}
			}
			///
		}
		///
		memory.Sort(delegate(MemoryItem item1, MemoryItem item2) { return item1.lastDistance.CompareTo(item2.lastDistance); });
	}
	void PerformClear()
	{
		for (int i = 0; i < memory.Count; ++i)
			if (memory[i].remainedTime.isReady())
			{
				memory.RemoveAt(i);
				--i;
			}
	}
}
