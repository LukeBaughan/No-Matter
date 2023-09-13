using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refract : MonoBehaviour
{

    [SerializeField] float refractiveIndex;

    Vector2 direction = Vector2.right;
    Vector2 colliderDirection;
    float dotProduct;

    private void OnTriggerEnter2D(Collider2D incidentCollider)
    {
        // Gets the dot product of the photon and the refraction zone
        colliderDirection = new Vector2(incidentCollider.transform.position.x - transform.position.x,
            incidentCollider.transform.position.y - transform.position.y) - Vector2.zero;
        dotProduct = Vector2.Dot(colliderDirection.normalized, direction.normalized);

        Photon player = incidentCollider.gameObject.GetComponent<Photon>();

        // Executes if photon collides with the object using this script
        if (player != null)
        {
            // Changes the direction of the photon, based on wether it is travelling left or right
            if (dotProduct < 0)
            {
                Debug.Log("LEFT");
            }
            if (dotProduct > 0)
            {
                Debug.Log("Right");
            }
        }
    }
}