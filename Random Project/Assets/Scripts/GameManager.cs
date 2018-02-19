using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	GameObject player;

	public ParticleSystem particleBlood;

#region inactive
	public float inactiveDistanceFromPlayer = 20.0f;
	public Timer inactiveTimeCheck;
	List<DistanceOptimalization> activeObjects = new List<DistanceOptimalization>();
	public void addToActivationList(DistanceOptimalization obj) { activeObjects.Add(obj); }
#endregion inactive

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
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
