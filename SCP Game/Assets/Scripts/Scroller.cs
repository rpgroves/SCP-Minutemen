using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        //this.transform.position.y += speed * Time.deltaTime;
        this.transform.Translate(0,speed * Time.deltaTime,0);
    }
}
