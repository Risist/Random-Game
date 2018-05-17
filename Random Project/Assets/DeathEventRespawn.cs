using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathEventRespawn : MonoBehaviour {

    public Transform respawnTransform;
    HealthController healthController;
    public Text leftLivesText;
    public int leftLives = 5;
    DeathEventPhysicsDestruction destr;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        destr = GetComponentInChildren<DeathEventPhysicsDestruction>();

        healthController.objectToRemove = null;
        healthController.removeAfterDeath = false;

        leftLivesText.text = "Left lives: " + leftLives;
    }

    void OnDeath(HealthController.DamageData data)
    {
        

        if (leftLives > 1)
        {
            healthController.actual = healthController.max;
            transform.position = respawnTransform.position;
            transform.rotation = respawnTransform.rotation;

            --leftLives;
            leftLivesText.text = "Left lives: " + leftLives;
        }
        else
        {
            destr.active = true;
            healthController.objectToRemove = healthController.gameObject;
            healthController.removeAfterDeath = true;
            destr.OnDeath(data);
            healthController.OnDeath(data);
            leftLivesText.text = "Left lives: " + "0";
        }        
    }
}
