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

	public List<AiUnitMind> agentsIsideArmy;
	public void AddAgent(AiUnitMind agent)
	{
		if (!agent || agent.myArmy == this)
			return; // already added or no agent has been passed to the function
		agentsIsideArmy.Add(agent);
		agent.myArmy = this;
	}

	public Vector2 GetCorrectionLocationAvoidance(Vector2 center, float minDistance, AiUnitMind ignoreAgent, float correctionDistance = 1.0f)
	{
		Vector2 correction = Vector2.zero;

		int i = 1;
		foreach( var it in agentsIsideArmy)
			if(it && it != ignoreAgent)
		{
			Vector2 distance = center - (Vector2)it.transform.position;
			float sqMag = distance.sqrMagnitude;
			if (sqMag < minDistance * minDistance)
			{
				distance -= distance.normalized * correctionDistance;
				++i;
			}
		}

		return center + correction;
	}

	private void Start()
	{
	}

	public void AddOrder(string name, Vector2 position, float radius, float time)
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
	public HasOrderReturn HasOrder(string name, Vector2 myPosition)
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
			AddAgent(mind);
		}
	}

}
