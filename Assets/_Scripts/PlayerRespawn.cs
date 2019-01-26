using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

   public Vector3 checkPoint;
   public float checkpointTimer = 2f;
   
   private void OnTriggerEnter2D(Collider2D other) {

      if (other.gameObject.layer == 11) {
         transform.position = checkPoint;
      }
      
   }

   private void OnCollisionStay2D(Collision2D other) {

      if (other.gameObject.layer == 9) {
         checkpointTimer += Time.deltaTime;
      }

      if (checkpointTimer > 2) {
         checkPoint = other.transform.position;
         checkPoint.y += 2;
      }
      
   }
   
   private void OnCollisionExit2D(Collision2D other) {

      if (other.gameObject.layer == 9) {
         checkpointTimer = 0;
      }
      
   }
   
   
}
