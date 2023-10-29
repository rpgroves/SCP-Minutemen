using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCutscene : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Animator myAnimator;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector2 rawInput;

    void Update()
    {
        if(rawInput.x < 0)
            SpriteFlip(true);
        if(rawInput.x > 0)
            SpriteFlip(false);

        HandleMovement(rawInput);
    }

    void SpriteFlip(bool isLeft)
    {
        if(isLeft)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    public void HandleMovement(Vector3 rawInput)
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    
        if(rawInput.x == 0 && rawInput.y == 0)
        {
            myAnimator.SetBool("isRunning", false);
            return;
        }
        
        myAnimator.SetBool("isRunning", true);
    }
}
