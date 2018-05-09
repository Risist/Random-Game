using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnCollision : MonoBehaviour
{
    public GameObject prefab;
    public string ignoreTag = "noTag";
    public string attachType;
    public bool onEnter = true;
    public bool onExit = false;
    public bool _collision= true;
    public bool trigger = true;
    public AiFraction fraction;

    public Timer attachCd = new Timer(0);

    private void Start()
    {
        attachCd.restart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!onEnter || !trigger)
            return;
        var otherFraction = collision.gameObject.GetComponent<AiFraction>();
        if (fraction && otherFraction && fraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
            return;

        var hp = collision.GetComponent<HealthController>();
        if (hp && hp.tag != ignoreTag && attachCd.isReadyRestart())
        {
            Attach(collision.gameObject);
        }
        else
        {
            var marker = collision.GetComponent<AttachWeaponMarker>();
            if (marker && marker.attachType == attachType)
                marker.activateMark();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!onExit || !trigger)
            return;
        var otherFraction = collision.gameObject.GetComponent<AiFraction>();
        if (fraction && otherFraction && fraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
            return;
        var hp = collision.GetComponent<HealthController>();
        if (hp && hp.tag != ignoreTag && attachCd.isReadyRestart())
        {
            Attach(collision.gameObject);
        }
        else
        {
            var marker = collision.GetComponent<AttachWeaponMarker>();
            if (marker && marker.attachType == attachType)
                marker.activateMark();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!onEnter || !_collision)
            return;
        var otherFraction = collision.gameObject.GetComponent<AiFraction>();
        if (fraction && otherFraction && fraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
            return;
        var hp = collision.gameObject.GetComponent<HealthController>();
        if (hp && hp.tag != ignoreTag && attachCd.isReadyRestart())
        {
            Attach(collision.gameObject);
        }
        else
        {
            var marker = collision.gameObject.GetComponent<AttachWeaponMarker>();
            if (marker && marker.attachType == attachType)
                marker.activateMark();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!onExit || !_collision)
            return;
        var otherFraction = collision.gameObject.GetComponent<AiFraction>();
        if (fraction && otherFraction && fraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
            return;
        var hp = collision.gameObject.GetComponent<HealthController>();
        if (hp && hp.tag != ignoreTag && attachCd.isReadyRestart())
        {
            Attach(collision.gameObject);
        }
        else
        {
            var marker = collision.gameObject.GetComponent<AttachWeaponMarker>();
            if (marker && marker.attachType == attachType)
                marker.activateMark();
        }
    }

    void Attach(GameObject obj)
    {
        var attaches = obj.GetComponentsInChildren<AttachBase>();
        foreach (var it in attaches)
            if (it.type == attachType)
            {
                it.stayTime.restart();
                return;
            }

        var v = Instantiate(prefab, obj.transform.position, obj.transform.rotation);
        v.transform.parent = obj.transform;
    }
}
