using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemBox : MonoBehaviour
{
    [SerializeField] GameObject ItemBoxImage;
    ItemSO item;

    Canvas canvas;
    Camera mainCamera;

    bool isMoving = false;

    void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(isMoving)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, Input.mousePosition, canvas.worldCamera, out position);
            position.x = position.x + 50;
            position.y = position.y - 50;
            transform.position = canvas.transform.TransformPoint(position);
        }
    }

    public void BeginEndMoving()
    {
        isMoving = !isMoving;
    }

    public void UpdateBox(ItemSO i)
    {
        Debug.Log("updating box");
        item = i;
        ItemBoxImage.GetComponent<Image>().sprite = item.getSpriteBlack();
    }
}
