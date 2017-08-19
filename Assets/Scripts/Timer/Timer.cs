using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public float targetTime = 60.0f;


    public void Update()
	{

		targetTime -= Time.deltaTime;
        OnTimerChanged(targetTime);

		if (targetTime <= 0.0f)
		{
            TimerEnded();
		}

	}

    void OnTimerChanged(float time) {
        
    }

	void TimerEnded()
	{
		//do your stuff here.
	}


}
