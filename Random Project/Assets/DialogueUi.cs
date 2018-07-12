using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUi : MonoBehaviour {

    public float distanceOffset;
    public Timer dissapearTimer;
    private Text im;
    Vector3 initialPosition;
    RectTransform rTransform;

	// Use this for initialization
	void Start () {
        im = GetComponentInChildren<Text>();
        dissapearTimer.restart();
        rTransform = GetComponent<RectTransform>();
        initialPosition = rTransform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float factor = Mathf.Clamp( (Time.time - dissapearTimer.actualTime)/dissapearTimer.cd, 0.0f, 1.0f);
        

        factor *= factor;
        factor *= factor;
        factor *= factor;
        factor *= factor;

        rTransform.position = initialPosition + new Vector3(0, factor, 0);
        Debug.Log(factor);
        Color cl = im.color;
        cl.a = 1 - factor;
        im.color = cl;

	}
}
