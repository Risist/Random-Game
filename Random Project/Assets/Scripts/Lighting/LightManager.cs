using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour {

    public static LightManager instance;

    public Image screenImage;
    public int powFadeLight = 5;
    public GameObject observer;


    float bestLightIntensitivitySq;

    [Range(0.0f, 1.0f)]
    public float minimalLight;
    [Range(0.0f, 1.0f)]
    public float maximalLight = 1.0f;

    public void checkLightSource(float intensitivitySq)
    {
        bestLightIntensitivitySq = intensitivitySq > bestLightIntensitivitySq
            ? intensitivitySq : bestLightIntensitivitySq;
    }
    // the far light source is from observer the darker is scene
    // if the distance is less than fullLightDistance then is used maximal available intensitivity
    // otherwise intensitivity becomes less the distance is bigger dependinglu on intensitivityFall parametr
    // at 0 intensitivityFall always max available is used
    // at 1 intensitivityFall light is seen only in fullLightDistance
    // last parametr : maxIntensitivityRatio changes power of light source
    // sould be in range of 0 to 1 includive
    public void checkLightSource(GameObject source, float fullLightDistance, 
        float intensitivityFall, float maxIntensitivityRatio)
    {
        // vialidance check
        if (observer == null || source == null)
            return;

        float distanceSq = (observer.transform.position - source.transform.position).sqrMagnitude;

        if (fullLightDistance * fullLightDistance > distanceSq)
            // in full light range
            checkLightSource(maximalLight * maximalLight * maxIntensitivityRatio * maxIntensitivityRatio);
        else
            // with changing light power
            checkLightSource(
            (maximalLight * maximalLight - (distanceSq - fullLightDistance * fullLightDistance) * intensitivityFall * intensitivityFall)
                * maxIntensitivityRatio * maxIntensitivityRatio
            );
    }



    // Use this for initialization
    void Start () {
        if (!observer)
            observer = GameObject.FindGameObjectWithTag("Player");

        instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
       // set new darkness level
        screenImage.color = new Color(0,0,0, 1.0f - Mathf.Clamp(
                Mathf.Pow(bestLightIntensitivitySq, powFadeLight)
                , minimalLight, maximalLight));

        // reset Light intensitivity
        bestLightIntensitivitySq = minimalLight * minimalLight;
    }
}


