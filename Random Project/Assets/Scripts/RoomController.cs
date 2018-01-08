using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : SpawnMethodBase {

	public SpawnListBase roomList;
	//public GameObject roomPrefab;

	public float roomSize;

	public int roomX, roomY;

	/// for checking whether to generate wall / nothing / another room
	GameManager manager;

	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();	
	}
	
	// Update is called once per frame
	void Update () {


		manager.signRoom(roomX, roomY);

		//if (roomPrefab)
			roomList.Spawn(Vector2.zero, Random.Range(0, 3) * 90.0f);
			//Instantiate(roomPrefab, transform.position, Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + Random.Range(0,3) * 90.0f ) );

		{
			if (!manager.hasRoom(roomX - 1, roomY))
			{
				var door = spawnList.Spawn(new Vector2(-roomSize, 0), 0).GetComponent<Door>();
				if(door)
				{
					door.roomX = roomX - 1;
					door.roomY = roomY;
					door.offset = new Vector2(-roomSize,0);
				}
			}

			if (!manager.hasRoom(roomX + 1, roomY))
			{
				var door = spawnList.Spawn(new Vector2(roomSize, 0), 180).GetComponent<Door>();
				if (door)
				{
					door.roomX = roomX + 1;
					door.roomY = roomY;
					door.offset = new Vector2(roomSize, 0);
				}
			}
			if (!manager.hasRoom(roomX, roomY - 1))
			{
				var door = spawnList.Spawn(new Vector2(0, -roomSize), 90).GetComponent<Door>();
				if (door)
				{
					door.roomX = roomX ;
					door.roomY = roomY - 1;
					door.offset = new Vector2(0, -roomSize);
				}
			}
			if (!manager.hasRoom(roomX, roomY + 1))
			{
				var door = spawnList.Spawn(new Vector2(0, roomSize), 270).GetComponent<Door>();
				if (door)
				{
					door.roomX = roomX ;
					door.roomY = roomY + 1;
					door.offset = new Vector2(0, roomSize);
				}
			}
		}

		/// remove RoomController after spawning room
		Destroy(gameObject);
	}


}
