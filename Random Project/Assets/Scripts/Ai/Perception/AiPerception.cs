using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Detects fraction objects.
 * Not designed to detect obstacles, only aims of attack, follow, cast spells ect
 */
public class AiPerception : MonoBehaviour {

    public static float scanTimeDiff = 0.25f;
    public float addictionalRotation = 0.0f;
    public Timer timerPerformSearch = new Timer();
	/// how far the field of view goes
	public float searchDistance = 5.0f;
	/// how many rays to shoot each search
	public int nRays = 5;
	/// radius of search cone the rays will be shooted from
	public float coneRadius = 100.0f;
	/// how long the target is remembered
	public float memoryTime = 5.0f;

    float scanTimeBase;

	public class MemoryItem
	{
		public Timer remainedTime;
		public AiPerceiveUnit unit;
		public float lastDistance;
	}
	[System.NonSerialized]
	public List<MemoryItem> memory = new List<MemoryItem>();

    private void Start()
    {
        scanTimeBase = timerPerformSearch.cd;
        timerPerformSearch.cd = scanTimeBase + Random.value * scanTimeDiff;
    }

    // Update is called once per frame
    void Update ()
	{
		if(timerPerformSearch.isReadyRestart())
		{
			PerformClear();
			PerformSearchNonTransparent();
            //PerformSearch();
        }
	}



    /// <summary>
    /// performs prception search over an environment where agents cant see through objects
    /// and adds perceived objects to the memory / refreshes memory
    /// </summary>
    void PerformSearchNonTransparent()
	{
        float angleOffset = coneRadius / nRays;

        for (int i = 0; i < nRays; ++i)
        {
            var rays = Physics2D.RaycastAll(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up, searchDistance);
            Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up * searchDistance, Color.green, 0.25f);

            var rayList = new List<RaycastHit2D>(rays);
            rayList.Sort(delegate (RaycastHit2D item1, RaycastHit2D item2) { return item1.distance.CompareTo(item2.distance); });

            foreach (var it in rayList)
            {
                var unit = it.collider.GetComponent<AiPerceiveUnit>();
                if (unit && unit.gameObject != gameObject)
                {
                    if (unit.distanceModificator * searchDistance > it.distance)
                        insertToMemory(unit, it.distance);

                    if (unit.blocksVision)
                        break;
                }
            }
            ///
        }
        ///
        memory.Sort(delegate (MemoryItem item1, MemoryItem item2) { return item1.lastDistance.CompareTo(item2.lastDistance); });
    }

    void PerformSearchNonTransparent2()
    {
        float angleOffset = coneRadius / nRays;

        for (int i = 0; i < nRays; ++i)
        {

            Vector2 dir = Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up;
            var hit = Physics2D.Raycast(transform.position,dir, searchDistance);

            Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up * searchDistance, Color.green, 0.25f);

            float distanceStack = 5.0f;

            int n = 20;

            while(hit)
            {
                var unit = hit.collider.GetComponent<AiPerceiveUnit>();
                if (unit && unit.gameObject != gameObject)
                {
                    if (unit.distanceModificator * (searchDistance - distanceStack) > hit.distance)
                        insertToMemory(unit, hit.distance);

                    if (unit.blocksVision)
                        break;
                }

                
                distanceStack += hit.distance;
                hit = Physics2D.Raycast((Vector2)transform.position + dir*distanceStack, dir, searchDistance - distanceStack);
                if (--n <= 0)
                {
                    Debug.LogError("endless loop - AiPerception::PerformSearch2 = " + hit.distance + ", " + distanceStack + ", " + hit.collider.gameObject);
                    break;
                }
            }

        }

        memory.Sort(delegate (MemoryItem item1, MemoryItem item2) { return item1.lastDistance.CompareTo(item2.lastDistance); });
    }

	void PerformSearch()
	{
		float angleOffset = coneRadius / nRays;

		for (int i = 0; i < nRays; ++i)
		{
			var rays = Physics2D.RaycastAll(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up, searchDistance);
			Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, -coneRadius * 0.5f + angleOffset * i + addictionalRotation) * transform.up * searchDistance, Color.green, 0.25f);

			foreach (var it in rays)
			{
				var unit = it.collider.GetComponent<AiPerceiveUnit>();
				if(unit && unit.gameObject != gameObject)
				{
					insertToMemory(unit, it.distance);
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

	public void insertToMemory(AiPerceiveUnit unit, float distance)
	{
		bool bFound = false;
		foreach (var itMemory in memory)
			if (itMemory.unit == unit)
			{
				itMemory.remainedTime.restart();
				itMemory.lastDistance = distance;
				bFound = true;
				break;
			}
		if (!bFound)
		{
			var memoryItem = new MemoryItem();
			memoryItem.unit = unit;
			memoryItem.remainedTime = new Timer(memoryTime);
			memoryItem.lastDistance = distance;

			memory.Add(memoryItem);
		}
	}
}
