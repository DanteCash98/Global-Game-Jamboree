using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
   public float PlayerHealth = 10f;
   private float LampLight = 10f;


   public void AddLight(float amount)
   {
      PlayerHealth += amount;
   }
   
   
}
