using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //rigidbody.AddForce(new Vector3(speed, 0.0f, 0.0f));
        this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
