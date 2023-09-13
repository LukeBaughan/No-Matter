using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public virtual void Restart()
    {
        GameManager.Instance.restart = true;
        GameManager.Instance.LoadScene(GameManager.scene.Level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
