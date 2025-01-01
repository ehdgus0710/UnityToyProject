using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TimeController))]
public class TimeControllerManager : Sington<TimeControllerManager>
{
    private TimeController timeController;
    public TimeController TimeController { get { return timeController; } }

    private void Start()
    {
        timeController = GetComponent<TimeController>();
    }

    public void SetTimeController(float targetTime, UnityAction endAction)
    {
        timeController.SetTimeController(targetTime, endAction);
    }

    public void SetFixedTimeController(float targetTime, UnityAction endAction)
    {
        timeController.SetFixedTimeController(targetTime, endAction);
    }
}
