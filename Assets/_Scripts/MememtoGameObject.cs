using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MememtoGameObject : MonoBehaviour, IInteractable
{
   
   //index of mememto in enum array
   [SerializeField] int mememtoType;

   public void Interact()
   {
       Player player = Player.instance;
       player.GetMememtos().Add((Player.Mememto) mememtoType);
       Destroy(gameObject);
   }
}
