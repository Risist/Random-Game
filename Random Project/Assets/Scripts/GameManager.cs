using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	GameObject player;

	public float inactiveDistanceFromPlayer = 20.0f;
	public Timer inactiveTimeCheck;
	List<DistanceOptimalization> activeObjects = new List<DistanceOptimalization>();
	public void addToActivationList(DistanceOptimalization obj) { activeObjects.Add(obj); }

	public int mapSizeX;
	public int mapSizeY;
	bool[,] mapRooms;

	int roomsOppen = 0;

	public void increaseRoomsOpen(int i) { roomsOppen += i;  }
	public int GetRoomsVisited()
	{
		return roomsOppen;
	}

	// Use this for initialization
	void Start () {
		mapRooms = new bool[mapSizeX, mapSizeY];
		for (int i = 0; i < mapSizeX; ++i)
			for (int j = 0; j < mapSizeY; ++j)
				mapRooms[i, j] = false;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	public bool hasRoom(int x, int y)
	{
		if (x < 0 || y < 0 || x >= mapSizeX || y >= mapSizeY)
			/// cant build here
			return true;

		return mapRooms[x, y];
	}
	public bool isInside(int x, int y)
	{
		return !(x < 0 || y < 0 || x >= mapSizeX || y >= mapSizeY);
	}
	public void signRoom(int x, int y)
	{
		mapRooms[x, y] = true;
		++roomsOppen;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Cancel"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if(inactiveTimeCheck.isReadyRestart() && player)
		{
			Vector3 playerPosition = player.transform.position;
			for(int i = 0; i < activeObjects.Count; )
				if(activeObjects[i])
				{
					activeObjects[i].gameObject.SetActive((
						activeObjects[i].transform.position - playerPosition).sqrMagnitude <
							(inactiveDistanceFromPlayer + activeObjects[i].distanceMidificator) *
							(inactiveDistanceFromPlayer + activeObjects[i].distanceMidificator) 
						);
					++i;
				}
				else
				{
					activeObjects.Remove(activeObjects[i]);
				}
		}
	}
}
