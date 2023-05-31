using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeleteScripot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Press;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        { 
            Press.gameObject.SetActive(false);
        }
    }
}
