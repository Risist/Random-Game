using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropSkill : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    ProgressionManager manager;
    public int skillNum;
    Image receivingImage;
    private Color normalColor;
    public Color highlightColor = Color.yellow;

    SkillPanel skillPanel;
    SkillPanel assignmentPanel;


    public void Awake()
    {
        manager = GameObject.Find("Player").GetComponent<ProgressionManager>();
        skillPanel = GameObject.Find("SkillPanel").GetComponent<SkillPanel>();
        assignmentPanel = GameObject.Find("SkillAssignmentPanel").GetComponent<SkillPanel>();
        receivingImage = gameObject.GetComponent<Image>();
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


        // Get skill we want to drop
        WeaponBase dropSkill = GetDropSkill(data);


        if (dropSkill != null)
        {
            // Checks if the same skill is in any of slots in Progress Manager
            int idx = manager.FindSkill(dropSkill);

            // If we find the same skill in any other slot, unbind it from other slot, update UI
            if (idx != -1) // && idx != skillNum)
            {
                manager.UnbindSlot(manager.slots[idx]);
                skillPanel.UnsetSkill(idx);
                assignmentPanel.UnsetSkill(idx);
            }

            // Bind skill to slot, update UI 
            manager.BindToSlot(dropSkill, manager.slots[skillNum]);
            skillPanel.SetSkill(skillNum, dropSkill);
            assignmentPanel.SetSkill(skillNum, dropSkill);
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (receivingImage == null)
            return;

        // Highlight the button we want to drop skill to
        Sprite dropSprite = GetDropSprite(data);
        if (dropSprite != null)
            receivingImage.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (receivingImage == null)
            return;

        // Remove the highlight from the button when we move away mouse
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
