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

    public void updateStatus(GameObject controller)
    {
        for(int x = 0; x < controllerStatus.Count; x++)
            if(controllers[x] == controller)
                controllerStatus[x] = !controllerStatus[x];

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
            //Debug.Log("sending signal...");
            for(int x = 0; x <= controllerStatus.Count; x++)
                ControlledEvent[x].GetComponent<Event>().EventTriggered();
        }
        else
        {
            //Debug.Log("sending signal...");
            for(int x = 0; x <= controllerStatus.Count; x++)
                ControlledEvent[x].GetComponent<Event>().EventStopped();
        }
    }
}
