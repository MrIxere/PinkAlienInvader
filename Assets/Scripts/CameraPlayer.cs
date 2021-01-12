using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
   public Transform playerCharacter;
   public float cameraDistance = 30.0f;
   public Transform left;
   public Transform right;
   public Transform bottom;
   public Transform top;

   private void Awake()
   {
      GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
   }

   private void FixedUpdate()
   {
      transform.position = new Vector3(playerCharacter.position.x, playerCharacter.position.y, transform.position.z);
      transform.position = Clamp(transform.position, 
         new Vector3(left.position.x, bottom.position.y, transform.position.z),
         new Vector3(right.position.x, top.position.y, transform.position.z));
   }

   private Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
   {
      return new Vector3
      {
         x = Mathf.Clamp(value.x, min.x, max.x),
         y = Mathf.Clamp(value.y, min.y, max.y),
         z = Mathf.Clamp(value.z, min.z, max.z)
      };
   }
}
