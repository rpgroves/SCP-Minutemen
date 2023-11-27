using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadStatusText;
    [SerializeField] float loadTime;
    [SerializeField] GameObject gbLoad;
    [SerializeField] GameObject gbText;
    Slider slider;
    float timer = 0.0f;
    bool isLoading = false;
    bool isLoaded = false;
    void Start()
    {
        loadStatusText.text = "...";
        Load();
    }

    void Update()
    {
        if(!isLoaded)
        {
            if(isLoading && timer < loadTime)
            {
                timer += Time.deltaTime;
                slider.value = timer/loadTime;
            }
            else
            {
                timer = 0;
                isLoading = false;
                loadStatusText.text = "Loaded!";
                PrintText();
            }
        }
        else
        {
            Debug.Log("printing");
        }
    }

    void Load()
    {
        gbLoad.SetActive(true);
        gbText.SetActive(false);
        slider = GetComponentInChildren<Slider>();
        isLoading = true;
        loadStatusText.text = "Loading...";
    }
    void PrintText()
    {
        gbLoad.SetActive(false);
        gbText.SetActive(true);
        isLoaded = true;
    }
}
