using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FateInfoPanel : MonoBehaviour
{



    [SerializeField]
    Text fateName;
    public Text Name { get { return fateName; } set { fateName = value; } }

    [SerializeField]
    Text level;
    public Text Level { get { return level; } set { level = value; } }

    [SerializeField]
    Text description;
    public Text Description { get { return description; } set { description = value; } }

    [SerializeField]
    Image icon;
    public Image Icon { get { return icon; } set { icon = value; } }

    bool isOccupied = false;
    public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }

    private void Awake()
    {
        Name = gameObject.GetComponentsInChildren<Text>(true)[0];
        Level = gameObject.GetComponentsInChildren<Text>(true)[1];
        Description = gameObject.GetComponentsInChildren<Text>(true)[2];
        Icon = gameObject.GetComponentInChildren<Image>();
    }
}

