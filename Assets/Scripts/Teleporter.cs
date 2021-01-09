using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //Player can interact with a door to "teleport" to another door
    
    public GameObject Door;
    public GameObject Player;

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
        Player.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, 
            0.0f);
    }
}