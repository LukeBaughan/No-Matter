using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : SingletonBase<CheckpointManager>
{
    public List<Checkpoint> checkPointList = new List<Checkpoint>();
    public int currentCheckpoint;

    // Used for changing the colour of the checkpoint sprite
    private Color redCheckpoint = new Color(1, 0.04095837f, 0);
    private Color yellowCheckpoint = new Color(1, 0.7182769f, 0);
    private Color greenCheckpoint = new Color(0, 1, 0.02717757f);

    public void addCurrentCheckpoint(Checkpoint checkpoint)
    {
        /* If the activated checkpoint is further along in the level than the current checkpoint,
        replace the current checkpoint with this and reset the death counter */
        if (checkPointList.IndexOf(checkpoint) > currentCheckpoint)
        {
            currentCheckpoint = checkPointList.IndexOf(checkpoint);
            GameManager.Instance.setGameCheckpoint(currentCheckpoint);
            GameManager.Instance.resetDeaths();
            GameManager.Instance.saveGame();
        }
    }

    public void FillCheckpointsList()
    {
        // Sets up the list of checkpoints in the level and sorts them by number
        checkPointList.Clear();
        checkPointList.AddRange(FindObjectsOfType<Checkpoint>());
        checkPointList = checkPointList.OrderBy(Checkpoint => Checkpoint.name).ToList();
        // Sets current checkpoint to the saved checkpoint
        currentCheckpoint = GameManager.Instance.getCurrentCheckpoint();
        // Sets the spawn location of the photon to current checkpoint location
        GameManager.Instance.spawnLocation = checkPointList[currentCheckpoint].transform.position;
    }

    // Changes the current checkpoint colour, based on how many times the player has died
    public void SetCurrentCheckpointColour(int deaths, int maxDeaths)
    {

        int deathsLeft = maxDeaths - deaths;
        SpriteRenderer checkpointSpriteRenderer = checkPointList[currentCheckpoint].GetComponent<SpriteRenderer>();

        // As the player gets closer to going back a checkpoint, the checkpoint changes it's colour from
        // green to yellow to red
        switch (deathsLeft)
        {
            case 0:
                checkpointSpriteRenderer.color = redCheckpoint;
                break;
            case 1:
                checkpointSpriteRenderer.color = yellowCheckpoint;
                break;
            default:
                checkpointSpriteRenderer.color = greenCheckpoint;
                break;
        }

    }
}
