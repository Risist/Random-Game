﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSkill : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Parameters of dragging template image
    public float iconAlpha;
    public float iconHeight;
    public float iconWidth;


    // Dictionaries for holding currently dragged skill
    private Dictionary<int, GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();
    private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();
    public Dictionary<int, WeaponBase> m_DraggingSkills = new Dictionary<int, WeaponBase>();

    public void OnBeginDrag(PointerEventData eventData)
    {
        // First find canvas of object
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        m_DraggingIcons[eventData.pointerId] = new GameObject("icon");
        m_DraggingIcons[eventData.pointerId].transform.SetParent(canvas.transform, false);
        m_DraggingIcons[eventData.pointerId].transform.SetAsLastSibling();
        

        var image = m_DraggingIcons[eventData.pointerId].AddComponent<Image>();
        // The icon will be under the cursor.
        // We want it to be ignored by the event system.
        var group = m_DraggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        // Set the parameters of the dragging template image
        image.rectTransform.sizeDelta = new Vector2(iconWidth, iconHeight);
        var tempColor = image.color;
        tempColor.a = iconAlpha;
        image.color = tempColor;
        image.overrideSprite = GetComponentsInChildren<Image>()[1].sprite;


        m_DraggingPlanes[eventData.pointerId] = canvas.transform as RectTransform;
        m_DraggingSkills[eventData.pointerId] = GetComponent<SkillSlot>().Skill;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons[eventData.pointerId] != null)
            SetDraggedPosition(eventData);
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {

        var rt = m_DraggingIcons[eventData.pointerId].GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlanes[eventData.pointerId], 
            eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlanes[eventData.pointerId].rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons[eventData.pointerId] != null)
            Destroy(m_DraggingIcons[eventData.pointerId]);

        m_DraggingIcons[eventData.pointerId] = null;
        m_DraggingSkills[eventData.pointerId] = null;
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        var t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}
