using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BaseTimerText : MonoBehaviour
{
    public void SetText(float time)
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = time.ToString("0.000");
    }
}
