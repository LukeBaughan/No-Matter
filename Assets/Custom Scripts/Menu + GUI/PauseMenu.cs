using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : SubsidiaryMenu
{
    public static bool gamePaused = false;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(gamePaused == true)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public override void GoToMainMenu()
    {
        base.GoToMainMenu();
        GameManager.Instance.stopTimerUpdate();
        UnPause();
    }

    public override void Restart()
    {
        base.Restart();
        UnPause();
    }
}
