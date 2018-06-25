using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FateSelectionSlot : MonoBehaviour
{
    [SerializeField]
    public ProgressionManager.Fate fate;
    [SerializeField]
    public Text fateName;
    [SerializeField]
    public Text level;
    [SerializeField]
    public Text description;
    [SerializeField]
    public Image icon;


    private void Awake()
    {

        fateName = gameObject.transform.Find("Background").Find("FateNameText").GetComponent<Text>();
        level = gameObject.transform.Find("Background").Find("FateLvlText").GetComponent<Text>();
        description = gameObject.transform.Find("Background").Find("FateDescriptionText").GetComponent<Text>();
        icon = gameObject.transform.Find("Background").Find("FateIconImage").GetComponent<Image>();

    }

}
