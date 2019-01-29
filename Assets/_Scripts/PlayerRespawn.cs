using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

   public Vector3 checkPoint;
   public float checkpointTimer = 2f;

   public float respawnWait = 2f;
   public float invlunerabilityTimer = 5f;

   private float deathTimer;
   
   void Update() {
      deathTimer += Time.deltaTime;
   }
   
   private void OnTriggerEnter2D(Collider2D other) {

      if (deathTimer < invlunerabilityTimer) {
         return;
      }

      if (other.gameObject.layer == 11) {
         StartCoroutine(Respawn());
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

   IEnumerator Respawn() {

      deathTimer = 0;
      
      GetComponent<SpriteRenderer>().color = Color.clear;
      float oldSpeed = GetComponent<PlayerMove>().runSpeed;
      GetComponent<PlayerMove>().runSpeed = 0;
      GetComponent<Rigidbody2D>().simulated = false;
      
      yield return new WaitForSeconds(respawnWait / 2);

      while (transform.position != checkPoint) {
         transform.position = transform.position.Lerp(checkPoint, 1);
         yield return null;
      }
      
      yield return new WaitForSeconds(respawnWait / 6);
      
      GetComponent<Rigidbody2D>().simulated = true;
      GetComponent<SpriteRenderer>().color = Color.white;
      GetComponent<PlayerMove>().runSpeed = oldSpeed;

      
   }
   
}
