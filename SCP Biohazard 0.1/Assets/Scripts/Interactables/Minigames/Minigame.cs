using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Minigame
{
   void MinigameTriggered(bool isActivated);
   void MinigameStopped();
   void SendSignal(bool wasWon);
   void setInteractable(Interactable i);
}
