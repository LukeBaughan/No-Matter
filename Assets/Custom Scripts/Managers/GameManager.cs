using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Data.SqlTypes;


// Uses singleton pattern to prevent multiple game mangers from being created
public class GameManager : SingletonBase<GameManager>
{
    // Used for saving data to a file
    public Game game;
    protected Game Game { get { return game; } set { game = value; } }

    public Vector2 spawnLocation;
    public bool restart = false;

    [SerializeField] private int maxDeaths = 3;

    // Enum used for switching scenes
    public enum scene
    {
        MainMenu,
        Level,
        LoseMenu,
        WinMenu
    }

    public override void Awake()
    {
        base.Awake();
        // Reads the save file 
        Game = FileReadWrite.Read();
    }

    public void LoadScene(scene sceneNum)
    {
        SceneManager.LoadScene((int)sceneNum);

        if (sceneNum == scene.Level)
        {
            Game = FileReadWrite.Read();

            // If the player restarts, the death counter and current checkpoint is reset
            if (restart == true)
            {
                Game.checkpoint = 0;
                restart = false;
            }

            /* If the player dies more than times than maxDeaths in a row, they lose their current checkpoint and 
            go back to the previous one unless they are already at the first checkpoint */
            if (Game.checkpoint > 0 && Game.consecutiveDeaths > maxDeaths)
            {
                Game.checkpoint--;
                setGameCheckpoint(Game.checkpoint);
                resetDeaths();
                saveGame();
            }

            if(Game.checkpoint == 0)
            {
                Game.levelCurrentTime = 0;
                resetDeaths();
            }
            // Adds the LoadCheckpoint to the sceneLoaded delegate to be called after the scene loads
            SceneManager.sceneLoaded += LoadCheckpoint;

        }
    }

    public void LoadCheckpoint(Scene loadedScene, LoadSceneMode mode)
    {
        // Sets up the checkpoint list and sets the photons spawn to the current checkpoint
        CheckpointManager.Instance.FillCheckpointsList();
        // Changes the current checkpoint colour, based on how many times the player has died
        CheckpointManager.Instance.SetCurrentCheckpointColour(Game.consecutiveDeaths, maxDeaths);
        Photon player = FindObjectOfType<Photon>();
        player.transform.position = spawnLocation;

        // Sets the time to the time that they left off at
        Timer.Instance.currrentTime = Game.levelCurrentTime;
        // Resumes the timer
        Timer.Instance.stopUpdate = false;
       
        Timer.Instance.InitUI();
    }

    // If the photon dies, increase the death counter by 1 and save the number of deaths
    public void OnDead()
    {
        stopTimerUpdate();
        Game.levelCurrentTime = Timer.Instance.currrentTime;
        LoadScene(scene.LoseMenu);
        Game.consecutiveDeaths++;
        saveGame();
        SceneManager.sceneLoaded -= LoadCheckpoint;
    }

    public void OnWin()
    {
        // Updates the win tracker
        Game.numOfWins++;

        // Stops the Timer
        stopTimerUpdate();
        // Updates the top completion times list and saves it to a binary file
        Timer.Instance.addBestTime(Game.bestTimes);
        Game.bestTimes = Timer.Instance.getTimeList();

        // Resets the death counter and the current checkpoint
        LoadScene(scene.WinMenu);
        resetDeaths();
        Game.checkpoint = 0;

        saveGame();

        SceneManager.sceneLoaded -= LoadCheckpoint;
    }

    public void loadBestTimes()
    {
        BestTimesManager.Instance.SetUpBestTimes(Game.bestTimes);
        WinTracker.Instance.SetText(Game.numOfWins);
    }

    public void saveGame()
    {
        FileReadWrite.Write(Game);
    }

    public void resetDeaths()
    {
        Game.consecutiveDeaths = 0;
    }

    public void setGameCheckpoint(int checkpoint)
    {
        Game.checkpoint = checkpoint;
    }

    public int getCurrentCheckpoint()
    {
        return Game.checkpoint;
    }

    public void stopTimerUpdate()
    {
        Timer.Instance.stopUpdate = true;
    }

    public float getCurrentTime()
    {
        return Timer.Instance.GetCurrentTime();
    }
}
