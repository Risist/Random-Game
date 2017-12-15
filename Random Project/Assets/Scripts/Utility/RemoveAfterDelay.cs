using UnityEngine;
using System.Collections;

public class RemoveAfterDelay : MonoBehaviour
{
    public Timer timer;

	private void Start()
	{
		timer.restart();
	}

	void Update()
    {
        if (timer.isReady())
            Destroy(gameObject);
    }
}
