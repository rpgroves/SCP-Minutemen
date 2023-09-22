using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent onTimePassed;
    int time;

    public void StartTimer(int t)
    {
        StartCoroutine("CalculateTime");
        StartCoroutine(CalculateTime());
    }

    IEnumerator CalculateTime()
    {
        yield return new WaitForSeconds(time);
        onTimePassed.Invoke();
    }
}
