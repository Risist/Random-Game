using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveFolder : MonoBehaviour {

    public float perspectiveFactor = 0;
    public float alphaFactor;
    Transform cameraTransform;
    Transform myTransform;

    SpriteRenderer[] sprites;
    Vector2[] initialPositionOffsets;
    float[] initialAlphas;

    // Use this for initialization
    void Start () {
        myTransform = transform;
		//cameraTransform = Camera.main.transform;
        cameraTransform = GameObject.FindGameObjectWithTag("Player").transform;
       
        sprites = GetComponentsInChildren<SpriteRenderer>();
        initialAlphas = new float[sprites.Length];
        initialPositionOffsets = new Vector2[sprites.Length];
        for(int i = 0; i < sprites.Length; ++i)
        {
            initialAlphas[i] = sprites[i].color.a;
            Color cl = sprites[i].color;
            cl.a = 0;
            sprites[i].color = cl;
            initialPositionOffsets[i] = (sprites[i].transform.position - myTransform.position);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!cameraTransform)
            return;
        Vector2 toCameraBase = cameraTransform.position - myTransform.position;
        float addPosFr = perspectiveFactor + GameManager.instance.addictionalPerspectiveFactor;
        float addAlphaFr = alphaFactor + GameManager.instance.addictionalPerspectiveAlphaFactor;
        if(toCameraBase.sqrMagnitude > GameManager.instance.addictionalPerspectiveMaxDist* GameManager.instance.addictionalPerspectiveMaxDist)
        {
            return;
        }

        for (int i = 0; i < sprites.Length; ++i)
        {
            Vector2 toCamera = toCameraBase + initialPositionOffsets[i];
            float length = toCamera.sqrMagnitude;

            sprites[i].transform.position = sprites[i].transform.parent.position + (Vector3)toCamera * length * addPosFr + sprites[i].transform.rotation * initialPositionOffsets[i];

            Color cl = sprites[i].color;
            cl.a = initialAlphas[i] - length * addAlphaFr;
            sprites[i].color = cl;
        }
    }
}
