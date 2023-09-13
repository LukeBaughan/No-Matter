using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        // Executes if photon collides with the checkpoint
        if (player != null)
        {
            CheckpointManager.Instance.addCurrentCheckpoint(this);
        }

   }
}