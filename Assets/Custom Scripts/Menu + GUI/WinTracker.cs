using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Made as a singleton, since I only plan to ever use this once
public class WinTracker : SingletonBase<WinTracker>
{
    public void SetText(int wins)
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = wins.ToString();
    }
}
