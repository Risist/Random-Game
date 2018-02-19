using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoolManager : MonoBehaviour {

	public GameObject prefab;
	public int initialCapacity
	{
		set { objects.Capacity = value; }
		get { return objects.Capacity; }
	}
	List<GameObject> objects = new List<GameObject>();

	public GameObject spawn(Vector2 position, float rotation)
	{
		foreach(var it in objects)
		{
			if(!it.activeInHierarchy)
			{
				it.transform.position = position;
				it.transform.rotation = Quaternion.Euler(0, 0, rotation);
				it.BroadcastMessage("OnRespawn");
				return it;
			}
		}
		var item = Instantiate(prefab, position, Quaternion.Euler(0,0,rotation));
		item.BroadcastMessage("OnRespawn");
		objects.Add(item);
		return item;
	}
}
