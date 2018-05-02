using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FateInfoPanel : MonoBehaviour
{

    [SerializeField]
    public Text fateName;
    [SerializeField]
    public Text level;
    [SerializeField]
    public Text description;
    [SerializeField]
    public Image icon;
    [SerializeField]
    public bool isOccupied;

    private void Awake()
    {
        fateName = gameObject.GetComponentsInChildren<Text>(true)[0];
        level = gameObject.GetComponentsInChildren<Text>(true)[1];
        description = gameObject.GetComponentsInChildren<Text>(true)[2];
        icon = gameObject.GetComponentInChildren<Image>();
    }
}

