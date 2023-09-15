using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Event
{
    [SerializeField] GameObject topLeftDoor;
    [SerializeField] GameObject topRightDoor;
    [SerializeField] GameObject botLeftDoor;
    [SerializeField] GameObject botRightDoor;

    [SerializeField] GameObject InteractableHandler;

    [SerializeField] bool isOpen = false;

    void Start()
    {
        if(isOpen)
        {
            OpenDoor();
        }
    }

    void Update()
    {
        
    }

    void OpenDoor()
    {
        if(!isOpen)
        {
            Vector3 newPositionTL = new Vector3(-0.9f, 0.0f, 0.0f);
            topLeftDoor.transform.position += newPositionTL;

            Vector3 newPositionTR = new Vector3(0.9f, 0.0f, 0.0f);
            topRightDoor.transform.position += newPositionTR;

            Vector3 newPositionBL = new Vector3(-0.9f, 0.0f, 0.0f);
            botLeftDoor.transform.position += newPositionBL;

            Vector3 newPositionBR = new Vector3(0.9f, 0.0f, 0.0f);
            botRightDoor.transform.position += newPositionBR;
            isOpen = true;
        }
    }

    void CloseDoor()
    {
        if(isOpen)
        {
            Vector3 newPositionTL = new Vector3(0.9f, 0.0f, 0.0f);
            topLeftDoor.transform.position += newPositionTL;

            Vector3 newPositionTR = new Vector3(-0.9f, 0.0f, 0.0f);
            topRightDoor.transform.position += newPositionTR;

            Vector3 newPositionBL = new Vector3(0.9f, 0.0f, 0.0f);
            botLeftDoor.transform.position += newPositionBL;

            Vector3 newPositionBR = new Vector3(-0.9f, 0.0f, 0.0f);
            botRightDoor.transform.position += newPositionBR;

            isOpen = false;
        }
    }

    public void EventTriggered()
    {
        OpenDoor();
    }

    public void EventStopped()
    {
        CloseDoor();
    }
}
