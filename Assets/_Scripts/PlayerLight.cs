using UnityEngine;

public class PlayerLight : MonoBehaviour
{
   public GameObject lamp;
   public float lamplight;

   private Vector3 originalScale;
   
   private void Start()
   {
      originalScale = lamp.transform.localScale;
   }

    public float AddLight(float light) {
        lamplight += light;
        return lamplight;
    }
   
   
}
