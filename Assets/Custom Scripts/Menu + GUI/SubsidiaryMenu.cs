using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsidiaryMenu : Menu
{
    public virtual void GoToMainMenu()
    {
        GameManager.Instance.LoadScene(GameManager.scene.MainMenu);
    }
}
