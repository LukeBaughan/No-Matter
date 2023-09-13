using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseMenu : SubsidiaryMenu, ILoadCheckpoint
{
    public void LoadCheckpoint()
    {
        GameManager.Instance.LoadScene(GameManager.scene.Level);
    }
}
