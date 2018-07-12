using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saddle : MonoBehaviour
{

    public GameObject root;
    public GameObject rider;
    PlayerMovement movement;
    Rigidbody2D riderBody;

    void Mount(GameObject obj)
    {
        riderBody = obj.GetComponent<Rigidbody2D>();
        riderBody.bodyType = RigidbodyType2D.Kinematic;

        movement = obj.GetComponent<PlayerMovement>();
        movement.rotateToDirection = false;
        movement.moveToDirection = false;
        movement.rideController = root.GetComponent<RideCthuluController>();

        var mountColliders = root.GetComponentsInChildren<Collider2D>(true);
        var riderColliders = riderBody.GetComponentsInChildren<Collider2D>(true);

        foreach (var itMount in mountColliders)
            foreach (var itRider in riderColliders)
                Physics2D.IgnoreCollision(itMount, itRider);
    }
    void DisMount(GameObject obj)
    {
        var mountColliders = root.GetComponentsInChildren<Collider2D>(true);
        var riderColliders = movement.GetComponentsInChildren<Collider2D>(true);

        foreach (var itMount in mountColliders)
            foreach (var itRider in riderColliders)
                Physics2D.IgnoreCollision(itMount, itRider, false);

        movement.rotateToDirection = true;
        movement.moveToDirection = true;
        movement = null;

        riderBody.bodyType = RigidbodyType2D.Dynamic;
        riderBody = null;
        rider = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rider)
            return;

        if (!root)
            DisMount(rider);

        movement.transform.position = transform.position;
        if (!movement.wereExternalRotationApplied())
            movement.transform.rotation = transform.rotation;
    }

    private void Start()
    {
        if (rider)
            Mount(rider);
    }
    private void OnDestroy()
    {
        if (rider)
            DisMount(rider);
    }
    private void OnEnable()
    {
        if (rider)
            Mount(rider);
    }
    private void OnDisable()
    {
        if (rider)
            DisMount(rider);
    }
    void OnDeath()
    {
        if (rider)
            DisMount(rider);
    }
}
