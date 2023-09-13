using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Game
{
    public int checkpoint;
    public int consecutiveDeaths;
    public List<float> bestTimes;
    public int numOfWins;
    public float levelCurrentTime;
}
