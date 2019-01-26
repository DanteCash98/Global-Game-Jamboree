using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MememtoGameObject : MonoBehaviour, IInteractable
{
   
   [SerializeField] int mememtoType;

   public void Interact()
   {
       Player player = Player.instance;
       player.GetMememtos().Add((Player.Mememto) mememtoType);
       Destroy(gameObject);
   }
}
