using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    
    void Start()
    {
        FunctionTimer.Create(TestingAction, 1f);
    }
    private void TestingAction()
    {
        Debug.Log("TimerTest!!");
    }
}
