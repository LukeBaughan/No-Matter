using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Photon player = collision.gameObject.GetComponent<Photon>();

        // Ends the game if the photon collides with the object using this script
        if (player != null)
        {
            GameManager.Instance.OnWin();
        }

    }

}
