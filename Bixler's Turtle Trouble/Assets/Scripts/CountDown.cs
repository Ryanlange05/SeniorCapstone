using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI words;
    public float currentTime = 0f;
    public float startingTime;
    public GameObject NPC;

    [SerializeField] TextMeshProUGUI CountdownText;
    private bool isCountingDown = false;

    public float CurrentTime => currentTime; // Getter for accessing currentTime

    void Start()
    {
        currentTime = startingTime;
        if (NPC != null)
        {
            NPC.gameObject.SetActive(false);
        }
        if (words != null)
        {
            words.gameObject.SetActive(true);
        }
        enabled = false; // Disable countdown functionality initially
    }

    void Update()
    {
        if (!isCountingDown)
            return;

        currentTime -= Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");
        if (currentTime <= 15f)
        {
            CountdownText.color = Color.red;
        }
        if (currentTime <= 0f)
        {
            currentTime = 0;
            Debug.Log("Here comes Dr. Wnek");

            if (NPC != null)
            {
                NPC.gameObject.SetActive(true);
            }
        }
        if (currentTime <= 80f)
        {
            words.gameObject.SetActive(false);
        }
    }

    public void StartTimer()
    {
        isCountingDown = true;
    }
}