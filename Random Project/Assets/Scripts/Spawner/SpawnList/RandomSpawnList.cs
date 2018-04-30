using UnityEngine;
using System.Collections;


/// Spawn list which spawns an object from list with random chance in distance (minimalDistance, maximal Distance from the game object containing RandomSpawnList script
public class RandomSpawnList : SpawnListBase {

	public Transform spawnParent;
	public bool myParent = false;
    public bool randomRotation;
    public bool randomPosition;

    /// data about sungular possibility of spawning an object
    [System.Serializable]
    public class SpawnStruct
    {
        // what to spawn
        public GameObject prefab;
        // how probably it is to be spawned
        public float chance;

		// where to spawn, somewhere in (min,max) distance from game object
		public float minimalDistance;
        public float maximalDistance;

		public Vector2 positionOffset;
		public float rotationOffset;

		public float GetDistance()
        {
            return Random.Range(minimalDistance, maximalDistance);
        }
    }
    public SpawnStruct[] objects;

	public void Start()
	{
		//var manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	public override GameObject Spawn()
    {
        float sum = 0;
        foreach (SpawnStruct it in objects)
            if (it.chance > 0)
                sum += it.chance;
        float randed = Random.Range(0, sum);

        float lastSum = 0;

        for (int i = 0; i < objects.Length; ++i)
            if (objects[i].chance > 0)
            {
                if (randed > lastSum && randed < lastSum + objects[i].chance)
                {
                    if (objects[i].prefab == null)
                        break;

                    float rot = 0;
                    if (randomRotation)
                        rot = Random.Range(0, 360);
                    else
                        rot = transform.rotation.eulerAngles.z;

                    Vector3 offset;
					if (randomPosition)
						offset = Quaternion.Euler(0, 0, Random.Range(0, 360))
						* new Vector3(objects[i].GetDistance(), 0);
					else
                        offset = new Vector3();

					Quaternion q = Quaternion.Euler(0, 0, rot + objects[i].rotationOffset);


					var obj = Instantiate(objects[i].prefab, gameObject.transform.position + offset + q*(Vector3)objects[i].positionOffset,
                        q);

					if (myParent)
						obj.transform.parent = transform.parent;
					else
						obj.transform.parent = spawnParent;

					return obj;
                }
                else
                {
                    lastSum += objects[i].chance;
                }
            }

		return null;
    }

	public override GameObject Spawn(Vector2 position, float rotation)
	{
		float sum = 0;
		foreach (SpawnStruct it in objects)
			if (it.chance > 0)
				sum += it.chance;
		float randed = Random.Range(0, sum);

		float lastSum = 0;

		for (int i = 0; i < objects.Length; ++i)
			if (objects[i].chance > 0)
			{
				if (randed > lastSum && randed < lastSum + objects[i].chance)
				{
					if (objects[i].prefab == null)
						break;

					float rot = 0;
					if (randomRotation)
						rot = Random.Range(0, 360);
					else
						rot = transform.rotation.eulerAngles.z;

					Vector3 offset;
					if (randomPosition)
						offset = Quaternion.Euler(0, 0, Random.Range(0,360))
						* new Vector3(objects[i].GetDistance(), 0);
					else
						offset = new Vector3();



					var obj = Instantiate(objects[i].prefab, gameObject.transform.position + offset + (Vector3)objects[i].positionOffset + (Vector3) position,
						Quaternion.Euler(0, 0, rot + objects[i].rotationOffset + rotation));

					if (myParent)
						obj.transform.parent = transform.parent;
					else
						obj.transform.parent = spawnParent;

					return obj;
				}
				else
				{
					lastSum += objects[i].chance;
				}
			}
		return null;
	}
}
