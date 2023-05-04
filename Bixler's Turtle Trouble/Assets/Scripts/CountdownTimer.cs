using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }
    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
