using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinTime : MonoBehaviour
{
    // Used Start method since there its only being used in the win screen (no init chains)
    void Start()
    {
        GetComponent<Text>().text = GameManager.Instance.getCurrentTime().ToString("F3");
    }

}
