using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 90f;
    public GameObject NPC;
    private bool isStarted;
    //GameObject NPC = GameObject.Find("NPC");
    [SerializeField] TextMeshProUGUI Warning;
    [SerializeField] TextMeshProUGUI CountdownText;
    public GameObject invisTurtle1;

    public void Start()
    {
        //currentTime = startingTime;
        if (NPC != null)
        {
            NPC.gameObject.SetActive(false);
        }
    }


    public void Update()
    {
        if (currentTime == 0f)
        {
            CountdownText.enabled = false;
        }

        startTimer();

        if (isStarted)
        {
            currentTime -= 1 * Time.deltaTime;
            CountdownText.text = currentTime.ToString();
            CountdownText.text = currentTime.ToString("0");
            if (currentTime <= 15f)
            {
                CountdownText.color = Color.red;
            }
            if (currentTime <= 0f)
            {
                currentTime = 0;
                Debug.Log("Here comes Dr. Wnek");
                //NPC = GameObject.Find("NPC");
                if (NPC != null)
                {
                    NPC.gameObject.SetActive(true);
                }

            }
        }

    }


    public void startTimer()
    {
        if (currentTime == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CountdownText.enabled = true;
                currentTime = startingTime;
                isStarted = true;
                Warning.text = "You have 90 seconds to hide the turtles";
                
                bool isActive = invisTurtle1.activeSelf;
                invisTurtle1.SetActive(!isActive);
            }
        }
    }


}