using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiArmy : MonoBehaviour {

	public Timer removeCd;
	public string fractionName;

	/// Agents can push order in specific range for restricted amount of time
	/// that agents in range will react to in some way (specified in their ai structure)
	[System.Serializable]
	public struct Order
	{
		public Vector2 position;
		public float radius;
		public string name;
		public Timer livetime;
	}

	List<Order> orders = new List<Order>();

	private void Start()
	{
		

	}

	public void addOrder(string name, Vector2 position, float radius, float time)
	{
		Order o = new Order();

		o.name = name;
		o.livetime = new Timer(time);
		o.position = position;
		o.radius = radius;

		o.livetime.restart();
		orders.Add(o);
	}

	public class HasOrderReturn
	{
		public Vector2 position;
		public float radius;
	}
	public bool HasOrder(string name, Vector2 myPosition)
	{
		foreach (var it in orders)
			if (name == it.name && (it.position - myPosition).sqrMagnitude < it.radius * it.radius)
				return true;
		return false;
	}
	public HasOrderReturn HasOrder_Struct(string name, Vector2 myPosition)
	{
		foreach (var it in orders)
			if (name == it.name && (it.position - myPosition).sqrMagnitude < it.radius * it.radius)
			{
				HasOrderReturn s = new HasOrderReturn();
				s.position = it.position;
				s.radius = it.radius;
				return s;
			}
		return null;
	}

	private void Update()
	{
		if (removeCd.isReadyRestart())
		{
			for (int i = 0; i < orders.Count; ++i)
				if (orders[i].livetime.isReady())
				{
					orders.RemoveAt(i);
					--i;
				}
		}
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		AiUnitMind mind = collision.gameObject.GetComponentInChildren<AiUnitMind>();
		if (mind && mind.myFraction.fractionName == fractionName)
		{
			mind.myArmy = this;
		}
	}

}
