using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public bool repeat = true;
    void Start()
    {
        source.clip = clip;
        if(repeat)
        {
            source.loop = true;
            source.Play();
        }
    }

    public void Play()
    {
        source.Play();
    }
}
