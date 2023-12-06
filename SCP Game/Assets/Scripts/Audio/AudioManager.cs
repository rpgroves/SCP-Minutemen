using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clipNeutral;
    public AudioClip clipFight1;
    public AudioClip clipFight2;
    public AudioClip clipBossFight;
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        int numManagers = FindObjectsOfType<AudioManager>().Length;
        if(numManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    void Start()
    {
        source.clip = clipNeutral;
        source.Play();
    }

    public void FightAudio()
    {
        source.Stop();
        source.clip = clipFight1;
        source.Play();
    }

    public void BossAudio()
    {
        source.Stop();
        source.clip = clipBossFight;
        source.Play();
    }

    public void NeutralAudio()
    {
        source.Stop();
        source.clip = clipNeutral;
        source.Play();
    }
}
