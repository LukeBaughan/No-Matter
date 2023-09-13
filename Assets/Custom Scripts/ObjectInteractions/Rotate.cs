using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool leftButtonDown = false;
    [SerializeField] private float rotationSpeed = 90.0f;
    private bool rotateClockwise = false;
    private bool rotateAntiClockwise = false;


    private void OnMouseOver()
    {
        //Checks if the right mouse button is being held down
        if (Input.GetMouseButtonDown(0))
        {
            leftButtonDown = true;
        }

        // Changes rotation direction based on what key is pressed
        if (Input.GetKeyDown("e"))
        {
            rotateClockwise = true;
        }

        if (Input.GetKeyUp("e"))
        {
            rotateClockwise = false;
        }


        if (Input.GetKeyDown("q"))
        {
            rotateAntiClockwise = true;
        }

        if (Input.GetKeyUp("q"))
        {
            rotateAntiClockwise = false;
        }
    }

    private void Update()
    {
        // Only Rotates the object if the player is still holding the left mouse button
        if (leftButtonDown)
        {
            if (rotateClockwise)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, rotationSpeed) * Time.deltaTime * -1, Space.World);
            }
            if (rotateAntiClockwise)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, (rotationSpeed * -1)) * Time.deltaTime * -1, Space.World);
            }
        }
    }

    // Prevents player from rotating after they let go of the left mouse button
    private void OnMouseUp()
    {
        rotateClockwise = false;
        rotateAntiClockwise = false;
        leftButtonDown = false;
    }
}
