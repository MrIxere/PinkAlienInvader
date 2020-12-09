using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform endTransform;

    private readonly Player player = null;

    private void ClimbDown()
    {
        player.transform.position = endTransform.position;
    }
}
