using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    private bool isDestroyed;
    private Action action;
    private float timer;
    public static FunctionTimer Create(Action action, float timer)
    {
        FunctionTimer functionTimer = new FunctionTimer(action, timer);

        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;


        return functionTimer;
    }

    //dummy class
    private class MonoBehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }
    
    public FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isDestroyed = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (!isDestroyed) { 
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            action();
        }
        DestroySelf();
    }
}
    private void DestroySelf()
    {
        isDestroyed = true;
    }
}
