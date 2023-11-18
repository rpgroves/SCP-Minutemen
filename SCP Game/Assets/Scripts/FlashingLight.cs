using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashingLight : MonoBehaviour
{
    public float timeLimit = 1.0f;
    float timer = 0.0f;
    float intensity = 1.0f;
    Light2D light;
    void Start()
    {
        light = GetComponent<Light2D>();
        intensity = light.intensity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeLimit)
        {
            timer = 0.0f;
            if(light.intensity == intensity)
                light.intensity = 0.0f;
            else
                light.intensity = intensity;
        }
    }
}
