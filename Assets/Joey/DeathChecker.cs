using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"collided with something: {other.gameObject.name}");
        if(other.tag == "enemy") {
            playerController.OnDeath();
        }
        if(other.tag == "end") {
            Debug.Log("END");
            playerController.OnWin();
        }
    }
}
