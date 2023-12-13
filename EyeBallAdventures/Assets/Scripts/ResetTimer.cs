using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimer
{
    private TimeCounter timeCounter;

   internal void ResetTime(GameObject canvas)
    {
        timeCounter = canvas.GetComponent<TimeCounter>();

        timeCounter.time = 0;
        timeCounter.seconds = 0;
        timeCounter.minutes = 0;
        timeCounter.timer.text = timeCounter.minutes.ToString("00") + ":" + timeCounter.seconds.ToString("00");
    }
}
