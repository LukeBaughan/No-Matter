using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private void OnMouseDrag()
    {
        // Allows player to click and drag objects which have this script (only when the game isn't paused)
        if (PauseMenu.gamePaused == false)
        {
            Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (_mousePosition);

            SetMirrorMoving(true);
        }
    }

    private void OnMouseUp()
    {
        SetMirrorMoving(false);
    }

    // Sets if the reflective objects is being moved by the player
    private void SetMirrorMoving(bool moving)
    {
        I_Reflective reflectiveObject = gameObject.GetComponent<Mirror>() as I_Reflective;
        if (reflectiveObject != null)
        {
            reflectiveObject.SetIsMoving(moving);
        }
    }
}
