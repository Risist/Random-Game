using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemAbilityBase : MonoBehaviour
{
    ItemManager itemManager;
    public ItemManager.ESkillRole role;

    EnergyController resource;
    public float cost;
    public float minimalEnergy;

    public Timer cd = new Timer(0.5f);
    public WeaponCommonCd[] commonCd;

    [System.NonSerialized]
    public new AudioSource audio;

    protected void Start()
    {
        resource = GetComponentInParent<EnergyController>();
        audio = GetComponent<AudioSource>();
        itemManager = GetComponentInParent<ItemManager>();
    }


    protected void PlaySound()
    {
        if (audio)
            audio.Play();
    }
    protected bool isButtonPressed()
    {
        return itemManager.isPressed(role) && !EventSystem.current.IsPointerOverGameObject();
    }
    protected bool CastSkill()
    {
        bool b = true;
        foreach (var it in commonCd)
            b = b && it.timer.isReady();

        if (b && isButtonPressed() && cd.isReady() && resource.HasEnough(cost + minimalEnergy)
            )
        {
            resource.Spend(cost);

            foreach (var it in commonCd)
                it.timer.restart();

            cd.restart();
            return true;
        }
        return false;
    }

}
