using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    
    public TextMeshProUGUI words;
    float currentTime = 0f;
    public float startingTime;
    public GameObject NPC;
    //GameObject NPC = GameObject.Find("NPC");

    [SerializeField] TextMeshProUGUI CountdownText;
    void Start()
    {
       
        currentTime = startingTime;
        if (NPC != null )
        {
            NPC.gameObject.SetActive(false);
        }
        if (words != null )
        {
            words.gameObject.SetActive(true);

        }
    }
  

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
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
            if (NPC != null )
            {
                NPC.gameObject.SetActive(true);
            }
   
        }
        if (currentTime <= 80f)
        {
                words.gameObject.SetActive(false);
        }

    }
}

