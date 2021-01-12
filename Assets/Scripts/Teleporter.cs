using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //Player can interact with a door to "teleport" to another door
    
    public GameObject door;
    public GameObject player;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds (0.5f);
        player.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, 
            0.0f);
    }
}