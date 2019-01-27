using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MememtoGameObject : MonoBehaviour, IInteractable
{
   
   //index of mememto in enum array
   [SerializeField] int mememtoType;

   private AudioSource memSource;

   public void Interact()
   {
       Player player = Player.instance;
       memSource = GetComponent<AudioSource>();
       player.GetMememtos().Add((Player.Mememto) mememtoType);
       memSource.Play();
       Destroy(gameObject);
   }
}
