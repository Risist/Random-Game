using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TogglePanel: MonoBehaviour 
{

	GameObject openedPanel;

    public Image lvlUpImage;
    public ProgressionManager progressionManager;

    private void Start()
    {
        openedPanel = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && openedPanel != null)
        {
            openedPanel.gameObject.SetActive(false);
            openedPanel = null;
        }


        //lvlUpImage.color = progressionManager.leftSkillPoints > 0 ? lvlUpColor : Color.black;
    }

    public void Paneltoggle(GameObject currentPanel)
	{
		if (openedPanel != null)
			openedPanel.gameObject.SetActive(false);

		if(openedPanel == currentPanel)
			openedPanel = null;
		else
		{
			openedPanel = currentPanel;
			openedPanel.gameObject.SetActive(true);
		}
	}
}
