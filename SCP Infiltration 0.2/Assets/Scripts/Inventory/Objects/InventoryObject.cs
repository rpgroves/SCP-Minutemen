using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryObject
{
   void OnTriggerEnter2D(Collider2D other);
   void OnTriggerExit2D(Collider2D other);
   InventoryObjectSO GetSO();
}
