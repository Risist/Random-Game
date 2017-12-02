using UnityEngine;
using System.Collections;

public class RemoveAfterDelay : MonoBehaviour
{
    public Timer timer;

    void Update()
    {
        if (timer.isReady())
            Destroy(gameObject);
    }
}
