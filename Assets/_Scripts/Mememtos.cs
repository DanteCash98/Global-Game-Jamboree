using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mememtos : MonoBehaviour, IInteractable
{
   public void Interact()
   {
       Debug.Log("hello");
       Player player = FindObjectOfType<Player>();
       player.GetMememtos().Add(this);
       gameObject.SetActive(false);
   }
}
