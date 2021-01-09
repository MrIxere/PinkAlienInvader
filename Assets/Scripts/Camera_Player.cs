﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player : MonoBehaviour
{
   public Transform playerCharacter;
   public float cameraDistance = 30.0f;

   private void Awake()
   {
      GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
   }

   private void FixedUpdate()
   {
      transform.position = new Vector3(playerCharacter.position.x, playerCharacter.position.y,transform.position.z);
   }
}
