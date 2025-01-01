using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeContainer
{
    public float currentTime = 0f;
    public float targetTime = 0f;
    public UnityAction endAction;

    public TimeContainer(float currentTime, float targetTime, UnityAction endAction)
    {
        this.currentTime = currentTime;
        this.targetTime = targetTime;

        if(endAction != null)
            this.endAction = endAction;
    }
}

public class TimeController : MonoBehaviour
{
    protected List<TimeContainer> deltaTimeActionList = new();

    private int deltaTimeActionListCount = 0;
    protected List<TimeContainer> fixedTimeActionList = new();
    private int fixedTimeActionListCount = 0;

    IEnumerator UpdateTime()
    { 
        while (deltaTimeActionListCount != 0)
        {
            for(int i = deltaTimeActionListCount - 1; i >= 0; --i)
            {
                deltaTimeActionList[i].currentTime += Time.deltaTime;

                if (deltaTimeActionList[i].currentTime >= deltaTimeActionList[i].targetTime)
                {
                    deltaTimeActionList[i].endAction?.Invoke();
                    deltaTimeActionList.Remove(deltaTimeActionList[i]);
                    --deltaTimeActionListCount;
                }
            }

            yield return new WaitForEndOfFrame();
        }

        if (0 > deltaTimeActionListCount)
            deltaTimeActionListCount = 0;
    }

    IEnumerator FixedUpdateTime()
    {
        while (fixedTimeActionListCount != 0)
        {
            for (int i = fixedTimeActionListCount - 1; i >= 0; --i)
            {
                fixedTimeActionList[i].currentTime += Time.deltaTime;

                if (fixedTimeActionList[i].currentTime >= fixedTimeActionList[i].targetTime)
                {
                    fixedTimeActionList[i].endAction?.Invoke();
                    fixedTimeActionList.Remove(fixedTimeActionList[i]);
                    --fixedTimeActionListCount;
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SetTimeController(float targetTime, UnityAction endAction)
    {
         ++deltaTimeActionListCount;

        deltaTimeActionList.Add(new TimeContainer(0f, targetTime, endAction));

        if (deltaTimeActionListCount == 1)
            StartCoroutine(UpdateTime());
    }

    public void SetFixedTimeController(float targetTime, UnityAction endAction)
    {
        ++fixedTimeActionListCount;

        fixedTimeActionList.Add(new TimeContainer(0f, targetTime, endAction));

        if (fixedTimeActionListCount == 1)
            StartCoroutine(FixedUpdateTime());
    }
}
