using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSkill : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    ProgressionManager manager;
    public int skillNum;
    public Image receivingImage;
    public Image skillPanelButton;
    public Image charPanelDarkMask;
    public Image skillPanelDarkMask;
    public Text charPanelCDText;
    public Text skillPanelCDText;
    public Sprite defaultSprite;
    private Color normalColor;
    public Color highlightColor = Color.yellow;

    public void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressionManager>();
        
    }

    public void OnEnable()
    {
        if (receivingImage != null)
            normalColor = receivingImage.color;
    }

    // Called when drops
    public void OnDrop(PointerEventData data)
    {
        // Resets color of skill button
        receivingImage.color = normalColor;

        // If no skill button to receive sprite
        if (receivingImage == null)
            return;

        // Get sprite we want to drop to skill button
        Sprite dropSprite = GetDropSprite(data);
        if (dropSprite != null)
        {
            // Override skill panel and char panel buttons sprites
            receivingImage.overrideSprite = dropSprite;
            skillPanelButton.overrideSprite = dropSprite;
        }

        // Get the skill we want to put into Progression Manager slot
        WeaponBase dropSkill = GetDropSkill(data);
        if(dropSkill != null)
        {
            // Checks if the same skill is in any of slots in Progress Manager
            int idx = manager.FindSkill(dropSkill);
            if (idx != -1 && idx != skillNum)
            {
                manager.UnbindSlot(manager.slots[idx]);

                GameObject skillButton = GameObject.FindGameObjectWithTag("SkillButton" + (idx + 1));
                GameObject charSkillButton = GameObject.FindGameObjectWithTag("CharSkillButton" + (idx + 1));
                skillButton.GetComponent<Image>().overrideSprite = defaultSprite;
                charSkillButton.GetComponent<Image>().overrideSprite = defaultSprite;
                skillButton.GetComponent<SkillCooldownUIDisplayer>().skill = null;
                skillButton.GetComponent<SkillCooldownUIDisplayer>().skillPanelCdText.GetComponent<Text>().enabled = false;
                charSkillButton.GetComponent<DropSkill>().skillPanelCDText.GetComponent<Text>().enabled = false;
            }

            manager.BindToSlot(dropSkill, manager.slots[skillPanelButton.GetComponent<SkillCooldownUIDisplayer>().skillNum]);
            skillPanelButton.GetComponent<SkillCooldownUIDisplayer>().skill = dropSkill;
            skillPanelCDText.GetComponent<Text>().enabled = true;
            charPanelCDText.GetComponent<Text>().enabled = true;
        }

    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (receivingImage == null)
            return;

        Sprite dropSprite = GetDropSprite(data);
        if (dropSprite != null)
            receivingImage.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (receivingImage == null)
            return;

        receivingImage.color = normalColor;
    }

    private Sprite GetDropSprite(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
            return null;

        var dragMe = originalObj.GetComponent<DragSkill>();
        if (dragMe == null)
            return null;

        var srcImage = originalObj.GetComponentsInChildren<Image>()[1];
        if (srcImage == null)
            return null;

        return srcImage.sprite;
    }

    private WeaponBase GetDropSkill(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
        {
            Debug.Log("got null on originalObj");
            return null;
        }      

        var dragMe = originalObj.GetComponent<DragSkill>();
        if (dragMe == null)
        {
            Debug.Log("got null on dragMe");
            return null;
        }

        var srcSkill = originalObj.GetComponent<DragSkill>().m_DraggingSkills[data.pointerId];
        if (srcSkill == null)
        {
            Debug.Log("got null on srcSkill");
            return null;
        }

        return srcSkill;
    }
}
