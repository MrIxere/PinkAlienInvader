using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //Player can interact with a door to "teleport" to another door
    
    [SerializeField] private Transform endTransform;

    public void Teleport()
    {
       transform.position = endTransform.position;
    }
}