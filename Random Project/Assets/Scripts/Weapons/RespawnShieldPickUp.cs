using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShieldPickUp : MonoBehaviour {

    public GameObject shieldPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var shield = Instantiate(shieldPrefab).GetComponent<ShieldController>();
            shield.linkToPlayer(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
