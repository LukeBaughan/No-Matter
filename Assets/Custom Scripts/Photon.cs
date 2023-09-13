using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon : MonoBehaviour
{
    public float speed = 5;
    // Sets up starting position
    [HideInInspector] public Vector2 direction = new Vector2(-1, -1);

    // Update is called once per frame
    void Update()
    {
        // Constanlty moves the photon
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
