using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 90f;

    [SerializeField] TextMeshProUGUI CountdownText;
    void Start()
    {
        currentTime = startingTime;
    }

 
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString();
    }
}
