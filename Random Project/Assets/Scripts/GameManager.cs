using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
	public GameObject player;
	public ParticleSystem particleBlood;
    public float addictionalPerspectiveFactor;
    public float addictionalPerspectiveAlphaFactor;
    public float addictionalPerspectiveMaxDist;

    // Use this for initialization
    void Start () {
        instance = this;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButton("ResetMap"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
