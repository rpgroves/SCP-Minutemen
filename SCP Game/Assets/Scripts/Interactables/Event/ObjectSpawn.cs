using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour, Event
{
    [SerializeField] List<GameObject> objects;

    public void EventTriggered()
    {
        foreach(GameObject ob in objects)
            ob.SetActive(true);
    }
    public void EventStopped()
    {
        foreach(GameObject ob in objects)
            ob.SetActive(false);
    }
}
