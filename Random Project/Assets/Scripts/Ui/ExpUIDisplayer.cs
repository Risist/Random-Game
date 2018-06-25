using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUIDisplayer : MonoBehaviour
{

    public bool updateProgress = true;
    ProgressionManager manager;
    Image image;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Player").GetComponent<ProgressionManager>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateProgress)
            image.fillAmount = manager.GetXpPercentage();
    }
}
