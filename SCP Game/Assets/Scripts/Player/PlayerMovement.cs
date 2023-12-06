using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    AudioSource source;
    public AudioClip walkClip;
    public AudioClip runClip;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float runMulti = 1.5f;
    float currentMoveSpeed = 0.0f;
    Animator myAnimator;
    Vector2 rawInput;
    bool isAudioPlaying = false;

    bool isPlayerInControl = true;
    bool isRunning = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
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
                isAudioPlaying = false;
                isRunning = false;
                source.Stop();
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
            if(!isAudioPlaying || !isRunning)
            {
                source.Stop();
                source.clip = runClip;
                source.Play();
                isAudioPlaying = true;
                isRunning = true;
            }
			currentMoveSpeed = moveSpeed * runMulti;
		}
        else 
        {
            if(!isAudioPlaying || isRunning)
            {
                source.Stop();
                source.clip = walkClip;
                source.Play();
                isAudioPlaying = true;
                isRunning = false;
            }
			currentMoveSpeed = moveSpeed;
		}
    }

    public void Run()
    {
        //moveSpeed = moveSpeed * runMulti;
    }
}
