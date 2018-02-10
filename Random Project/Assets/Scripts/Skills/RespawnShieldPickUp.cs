using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShieldPickUp : MonoBehaviour {

    public GameObject shieldPrefab;
	public int nMin = 1;
	public int nMax = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			int n = Random.Range(nMin, nMax);
			for (int i = 0; i < n; ++i)
			{
				var shield = Instantiate(shieldPrefab).GetComponent<ShieldController>();
				shield.linkToPlayer(collision.gameObject);
			}

            Destroy(gameObject);
        }
    }
}
