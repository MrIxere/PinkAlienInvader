using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //Makes the player respawn and the death zone

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawn.transform.position;
            Physics.SyncTransforms();
        }
    }
}
