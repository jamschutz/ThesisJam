using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    public PlayerController playerController;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"collided with something: {other.gameObject.name}");
        if(other.tag == "enemy") {
            playerController.OnDeath();
        }
    }
}
