using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIDisplayer : MonoBehaviour
{

    int sceneCount;
    public List<string> scenes = new List<string>();
    public GameObject content;
    public LevelButton levelButton;
    public string[] sceneNames;
    public Sprite[] sceneSprites;
    private void Awake()
    {
        content = GameObject.Find("Content");

        // Get the nuber of scenes in build
        sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

        //for (int idx = 0; idx < sceneCount; idx++)
        //    scenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(idx)));

        GenerateLevelButtons();
    }


    void GenerateLevelButtons()
    {
        if (sceneCount == 0)
            return;

        for (int idx = 1; idx < sceneCount; idx++)
        {
            
            var button = Instantiate(levelButton) as LevelButton;
            //button.levelname.text = scenes[idx];
            //button.levelDescription.text = idx.ToString();
            button.gameObject.transform.SetParent(content.transform, false);
            button.sceneId = idx;
            button.sceneImage.sprite = sceneSprites[idx - 1];
            button.sceneText.text = sceneNames[idx - 1];
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
