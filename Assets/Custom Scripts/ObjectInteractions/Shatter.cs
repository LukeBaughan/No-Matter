using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetMirrorMoving() == false)
        {
            Photon player = collision.gameObject.GetComponent<Photon>();
            // Shatters if photon collides with the reflective object AND if the object is stationary
            if (player != null)
                Destroy(gameObject);
        }

    }

    private bool GetMirrorMoving()
    {
        I_Reflective reflectiveObject = gameObject.GetComponent<Mirror>() as I_Reflective;
        if (reflectiveObject != null)
        {
            return reflectiveObject.GetIsMoving();
        }
        else
        {
            return false;
        }
    }

}