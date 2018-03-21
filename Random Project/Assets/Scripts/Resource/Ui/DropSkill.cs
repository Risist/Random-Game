using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSkill : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ProgressionManager manager;
    public Image containerImage;
    public Image receivingImage;
    public Image skillPanelButton;
    public Image darkMask;
    public Image skillPanelDarkMask;
    private Color normalColor;
    public Color highlightColor = Color.yellow;

    public void OnEnable()
    {
        if (containerImage != null)
            normalColor = containerImage.color;
    }

    public void OnDrop(PointerEventData data)
    {
        containerImage.color = normalColor;

        if (receivingImage == null)
            return;

        Sprite dropSprite = GetDropSprite(data);
        if (dropSprite != null)
        {
            receivingImage.overrideSprite = dropSprite;
            //darkMask.overrideSprite = dropSprite;
            skillPanelButton.overrideSprite = dropSprite;
            //skillPanelDarkMask.overrideSprite = dropSprite;
        }

        WeaponBase dropSkill = GetDropSkill(data);
        Debug.Log("Drop skil =" + dropSkill.displayName.ToString());
        manager.BindToSlot(dropSkill, manager.slots[skillPanelButton.GetComponent<SkillCooldownUIDisplayer>().skillNum]);
        skillPanelButton.GetComponent<SkillCooldownUIDisplayer>().skill = dropSkill;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (containerImage == null)
            return;

        Sprite dropSprite = GetDropSprite(data);
        if (dropSprite != null)
            containerImage.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (containerImage == null)
            return;

        containerImage.color = normalColor;
    }

    private Sprite GetDropSprite(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
            return null;

        var dragMe = originalObj.GetComponent<DragSkill>();
        if (dragMe == null)
            return null;

        //var srcImage = originalObj.GetComponent<Image>();
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

        //var srcImage = originalObj.GetComponent<Image>();
        var srcSkill = originalObj.GetComponent<DragSkill>().m_DraggingSkills[data.pointerId];
        if (srcSkill == null)
        {
            Debug.Log("got null on srcSkill");
            return null;
        }

        return srcSkill;
    }
}
