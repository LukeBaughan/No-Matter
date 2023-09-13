using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu, ILoadCheckpoint
{
    public void LoadCheckpoint()
    {
        GameManager.Instance.LoadScene(GameManager.scene.Level);
    }

    public void LoadBestTimes()
    {
        GameManager.Instance.loadBestTimes();
    }
}
