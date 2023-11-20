using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float runMulti = 1.5f;
    float currentMoveSpeed = 0.0f;
    Animator myAnimator;
    Vector2 rawInput;
    bool isRunning;

    bool isPlayerInControl = true;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void HandlePlayerDeath()
    {
        myAnimator.SetBool("isRunning", false);
        myAnimator.SetBool("isDead", true);
    }

    public void HandleMovement(Vector3 rawInput)
    {
        if(isPlayerInControl)
        {
            Vector3 delta = rawInput * currentMoveSpeed * Time.deltaTime;
            transform.position += delta;
        
            if(rawInput.x == 0 && rawInput.y == 0)
            {
                myAnimator.SetBool("isRunning", false);
                myAnimator.SetBool("isIdle", true);
                return;
            }
            
            myAnimator.SetBool("isRunning", true);
            myAnimator.SetBool("isIdle", false);

            rawInput.Normalize();
            myAnimator.SetFloat("X Comp", rawInput.x);
            myAnimator.SetFloat("Y Comp", rawInput.y);
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
			currentMoveSpeed = moveSpeed * runMulti;
		}
        else 
        {
			currentMoveSpeed = moveSpeed;
		}
    }

    public void Run()
    {
        //moveSpeed = moveSpeed * runMulti;
    }
}
