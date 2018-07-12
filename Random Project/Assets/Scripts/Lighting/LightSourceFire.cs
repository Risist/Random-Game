using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceFire : LightSource {

    public float changeRangeMin = -0.006f;
    public float changeRangeMax = 0.0075f;
    public float minLight = 0.0f;
    public float maxLight = 1.0f;

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        maxIntensitivityRatio += Random.Range(changeRangeMin, changeRangeMax);
        maxIntensitivityRatio = Mathf.Clamp(maxIntensitivityRatio, minLight, maxLight);
    }
}
