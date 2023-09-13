using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class BestTimesManager : SingletonBase<BestTimesManager>
{

    List<LeaderboardText> bestTimesTextList = new List<LeaderboardText>();

    public void SetUpBestTimes(List<float> times)
    {
        if(times != null)
        {
            // Gets all of the loaderboard text objects in-order and sets the text to the player's best completion times
            bestTimesTextList.Clear();
            bestTimesTextList.AddRange(FindObjectsOfType<LeaderboardText>());
            bestTimesTextList = bestTimesTextList.OrderBy(LeaderboardText => LeaderboardText.name).ToList();

            for (int i = 0; i <= times.Count - 1; i++)
            {
                bestTimesTextList[i].SetText(times[i]);
            }
        }
    }

}
