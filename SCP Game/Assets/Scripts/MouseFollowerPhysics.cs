using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Camera mainCamera;
    [SerializeField] Sprite keycardSprite;

    void Awake()
    {
        canvas = transform.root.GetComponentInChildren<Canvas>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, Input.mousePosition, canvas.worldCamera, out position);
        GetComponent<Rigidbody2D>().AddForce(canvas.transform.TransformPoint(position) - transform.position);
        //transform.position = canvas.transform.TransformPoint(position);
    }

    void BeginDrag()
    {
        
    }
}
