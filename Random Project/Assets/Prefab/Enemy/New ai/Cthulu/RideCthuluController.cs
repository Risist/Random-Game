using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideCthuluController : MonoBehaviour {

    #region targetChoosing
    public bool autoChooseTarget;
    public AiLocationBase locationToFollow;
    [Range(0.0f, 1.0f)]
    public float autoTargetScale = 1.0f;

    Vector2 m_target;
    bool appliedExternalTarget = false;
    public void selectTarget(Vector2 target, float avg = 1.0f)
    {
        m_target = 
            m_target * (1.0f - avg) 
            + target * avg;
        appliedExternalTarget = true;
    }
    public void selectTargetOffset(Vector2 target, float avg = 1.0f)
    {
        m_target = rb.position + 
            m_target * (1.0f - avg)
            + target * avg;
        appliedExternalTarget = true;
    }

    private void Update()
    {
        if(autoChooseTarget && locationToFollow)
        {
            selectTarget(locationToFollow.GetLocation(), //autoTargetScale);
                appliedExternalTarget ? autoTargetScale : 1.0f);
        }//else
            //selectTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }
    private void LateUpdate()
    {
        appliedExternalTarget = false;
    }

    #endregion targetChoosing



    #region movement
    [HideInInspector]
    public Rigidbody2D rb;

    

    public float torqueMin = -5;
    public float torqueMax = 5;

    [Range(0.0f, 1.0f)]
    public float averageFactor = 0;

    [Range(0.0f, 1.0f)]
    public float followFactor = 0;

    float averageTorque; public float followScale = 0.1f;

    // Use this for initialization
    void Start () {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 toFollow = m_target - rb.position;
        float followDir = Quaternion.FromToRotation(Vector2.up, toFollow).eulerAngles.z;
        followDir = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, followDir);

        averageTorque = averageTorque * averageFactor + Random.Range(torqueMin, torqueMax) * Time.fixedDeltaTime * (1 - averageFactor);
        rb.AddTorque(followDir * followFactor + averageTorque * (1 - followFactor));
        
    }
    #endregion movement

}
