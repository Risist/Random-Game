using UnityEngine;
using System.Collections;

public class RemoveAfterDelay : MonoBehaviour
{
    public Timer timer;
	//float timeLeft;

	private void Start()
	{
		timer.restart();
		//timeLeft = timer.cd;
	}

	void Update()
    {
        if (timer.isReady())
            Destroy(gameObject);
    }

	private void OnDisable()
	{
		//timeLeft = timer.cd - (Time.time - timer.actualTime);
	}
	private void OnEnable()
	{
		//if(timer != null)
			//timer.cd = timeLeft;
	}
}
