using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : SingletonBase<Timer>
{
    public float currrentTime = 0;
    public bool stopUpdate = false;
    List<float> timeList;
    List<LevelTimeUI> timeUI = new List<LevelTimeUI>();


    public void InitUI()
    {
        // Gets the UI text
        timeUI.Clear();
        timeUI.AddRange(FindObjectsOfType<LevelTimeUI>());
    }

    public void Update()
    {
        // Updates the timer when the level starts
        if (!stopUpdate)
        {
            currrentTime += Time.deltaTime;
            // Updates the UI text
            timeUI[0].SetText(currrentTime);
        }
    }

    public void addBestTime(List<float> topTimes)
    {
        // If the list hasn't been initialised then initialise it
        if (topTimes == null)
        {
            topTimes = new List<float>();
        }

        // If the new completion time is faster than the slowest time in the list, replace it 
        if (topTimes.Count >= 10)
        {
            topTimes.Sort();
            for(int i = topTimes.Count - 1; i > -1; i--)
            {
                if(currrentTime <= topTimes[i])
                {
                    topTimes[i] = currrentTime;
                    break;
                }
            }
        }
        // If the list isnt full then just add the time to the list
        else
        {
            topTimes.Add(currrentTime);
        }

        topTimes.Sort();
        timeList = topTimes;
    }

    public List<float> getTimeList()
    {
        return timeList;
    }

    public float GetCurrentTime()
    {
        return currrentTime;
    }
}
