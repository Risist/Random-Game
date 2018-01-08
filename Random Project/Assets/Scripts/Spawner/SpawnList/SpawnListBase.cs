using UnityEngine;
using System.Collections;

public abstract class SpawnListBase : MonoBehaviour {

    public abstract GameObject Spawn();
	public abstract GameObject Spawn(Vector2 position, float rotation);
}
