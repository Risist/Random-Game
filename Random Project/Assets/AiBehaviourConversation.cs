using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiBehaviourConversation : AiBehaviourBase {

    public Vector3 spawnOffset;
    public GameObject dialogueCanvasPrefab;
    public Timer resetTimer;
    public string[] sentences;
    int current = 0;
    public bool repeat;
    public bool random;

    new private void Start()
    {
        base.Start();
        resetTimer.restart();
    }

    public override void EnterAction()
    {
        var d = Instantiate(dialogueCanvasPrefab, transform.position + spawnOffset, dialogueCanvasPrefab.transform.rotation);
       
        if (random)
        {
            d.GetComponentInChildren<Text>().text 
                = sentences[Random.Range(0, sentences.Length)];
        }
        else
        {
            if (resetTimer.isReady())
                current = 0;
            resetTimer.restart();

            d.GetComponentInChildren<Text>().text = sentences[current];

            if (current < sentences.Length - 1)
                ++current;
            else if (repeat)
                current = 0;
        }
    }

    public override bool CanEnter()
    {
        return repeat || current < sentences.Length;
    }
}
