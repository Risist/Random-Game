using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject roomPrefab;
	public Vector2 offset;
	bool roomSpawned = false;

	public int roomX, roomY;
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player" && roomSpawned == false)
		{
			GetComponent<Animator>().SetBool("Open", true);

			var manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
			if (!manager.hasRoom(roomX, roomY))
			{
				var obj = Instantiate(roomPrefab, transform.position + (Vector3)offset, Quaternion.identity);
				var room = obj.GetComponent<RoomController>();
				room.roomX = roomX;
				room.roomY = roomY;
			}
			roomSpawned = true;
		}
	}
}
