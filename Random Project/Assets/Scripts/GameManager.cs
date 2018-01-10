using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int mapSizeX;
	public int mapSizeY;
	bool[,] mapRooms;

	// Use this for initialization
	void Start () {
		mapRooms = new bool[mapSizeX, mapSizeY];
		for (int i = 0; i < mapSizeX; ++i)
			for (int j = 0; j < mapSizeY; ++j)
				mapRooms[i, j] = false;
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
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Cancel"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
