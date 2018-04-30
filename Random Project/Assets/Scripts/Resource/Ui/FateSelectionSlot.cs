using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FateSelectionSlot : MonoBehaviour
{

    //public ProgressionManager.Fate Fate { get; set; }
    public Text Name { get; set; }
    public Text Level { get; set; }
    public Text Description { get; set; }
    public Image Icon { get; set; }


    private void Awake()
    {

        Name = gameObject.transform.Find("Background").Find("FateNameText").GetComponent<Text>();
        Level = gameObject.transform.Find("Background").Find("FateLvlText").GetComponent<Text>();
        Description = gameObject.transform.Find("Background").Find("FateDescriptionText").GetComponent<Text>();
        Icon = gameObject.transform.Find("Background").Find("FateIconImage").GetComponent<Image>();

    }

}
