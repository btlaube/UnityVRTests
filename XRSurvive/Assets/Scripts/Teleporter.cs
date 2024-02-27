using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform destinationPos;
    public Transform camera;

    void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player"))  // Assuming the player has a "Player" tag.
        // {
            TeleportPlayer(other.transform);
        // }
    }

    void TeleportPlayer(Transform playerTransform)
    {
        camera.position = destinationPos.position;
    }
}
