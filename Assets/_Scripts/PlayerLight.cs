using UnityEngine;

public class PlayerLight : MonoBehaviour
{
   public GameObject lamp;
   public Light lamplight;

   private Vector3 originalScale;
   
   private void Start()
   {
      originalScale = lamp.transform.localScale;
   }

   public void AddLight(float amount)
   {
      lamplight.intensity += amount;
      if (lamp.transform.localScale.x + amount <= 0 || lamp.transform.localScale.x + amount >= originalScale.x ) return;
      lamp.transform.localScale += new Vector3(amount,amount,amount);
   }
   
   
}
