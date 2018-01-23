using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : SpawnMethodBase {

	public SpawnListBase roomList;
	public GameObject wallPrefab;

	public float roomSize;

	public int roomX, roomY;

	/// for checking whether to generate wall / nothing / another room
	GameManager manager;

	new void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();	
	}
	
	// Update is called once per frame
	void Update () {


		manager.signRoom(roomX, roomY);
		
		roomList.Spawn(Vector2.zero, 0);
	
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
			}else if( !manager.isInside(roomX - 1, roomY))
				Instantiate(wallPrefab, transform.position + new Vector3(-roomSize, 0, 0), Quaternion.identity);


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
			else if (!manager.isInside(roomX + 1, roomY))
				Instantiate(wallPrefab, transform.position + new Vector3(roomSize, 0, 0), Quaternion.identity);



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
			else if (!manager.isInside(roomX, roomY-1))
				Instantiate(wallPrefab, transform.position + new Vector3(0, -roomSize, 0), Quaternion.identity);


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
			else if (!manager.isInside(roomX, roomY + 1))
				Instantiate(wallPrefab, transform.position + new Vector3(0, roomSize, 0), Quaternion.identity);


		}

		/// remove RoomController after spawning room
		Destroy(gameObject);
	}


}
