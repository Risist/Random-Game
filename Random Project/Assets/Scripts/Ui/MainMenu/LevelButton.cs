using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelButton : MonoBehaviour
{
    //public Image image;
    //public Text levelname;
    //public string levelname;
    public int sceneId = 0;
    public Image sceneImage;
    public Text sceneText;
    //public Text levelDescription;

    private void Awake()
    {
        //image = GetComponent<Image>();
        //levelname = GetComponentsInChildren<Text>()[0];
        //levelDescription = GetComponentsInChildren<Text>()[1];
    }

    public void OnSubmit()
    {
        //if(levelname.text != "")
        SceneManager.LoadScene(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(sceneId)));
    }

}
