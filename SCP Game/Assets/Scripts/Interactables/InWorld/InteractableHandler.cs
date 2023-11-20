using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandler : MonoBehaviour
{
    [SerializeField] GameObject[] controllers;
    [SerializeField] GameObject[] ControlledEvent;
    List<bool> controllerStatus = new List<bool>();

    void Start()
    {
        for(int x = 0; x < controllers.Length; x++)
            controllerStatus.Add(false);
    }

    void Update()
    {
        
    }

    public void updateStatus(GameObject controller, bool isOn)
    {
        for(int x = 0; x < controllerStatus.Count; x++)
            if(controllers[x] == controller)
            {
                controllerStatus[x] = isOn;
            }

        bool allTrue = true;
        for(int x = 0; x < controllerStatus.Count; x++)
        {
            if(controllerStatus[x] == false)
            {
                allTrue = false;
            }
        }

        if(allTrue)
        {
            Debug.Log("sending start signal");
            for(int x = 0; x < ControlledEvent.Length; x++)
                ControlledEvent[x].GetComponent<Event>().EventTriggered();
        }
        else
        {
            Debug.Log("sending stop signal");
            for(int x = 0; x < ControlledEvent.Length; x++)
                ControlledEvent[x].GetComponent<Event>().EventStopped();
        }
    }
}
