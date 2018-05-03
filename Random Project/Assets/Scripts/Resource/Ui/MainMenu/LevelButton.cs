using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelButton : MonoBehaviour
{
    public Image image;
    public Text levelname;
    public Text levelDescription;

    private void Awake()
    {
        image = GetComponent<Image>();
        levelname = GetComponentsInChildren<Text>()[0];
        levelDescription = GetComponentsInChildren<Text>()[1];
    }

    public void OnSubmit()
    {
        if(levelname.text != "")
            SceneManager.LoadScene(levelname.text);
    }

}
