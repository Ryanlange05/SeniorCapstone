using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 90f;

    [SerializeField] Text CountDownText;
    void Start()
    {
        currentTime = startingTime;
    }

 
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountDownText.text = startingTime.ToString();
    }
}
