using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour, ITimer {

    [SerializeField]
    private float initTime = 10;
    
    public float CurrentTime { get; private set; }
    public bool IsActive { get; private set; }
    
    public event EventHandler OnTimerElapse;

    private void Update() {
        if (!IsActive) return;
        if (CurrentTime <= 0) {
            Stop();
            return;
        }
        CurrentTime -= Time.deltaTime;
    }

    public void Initialize() {
        CurrentTime = initTime;
        IsActive = true;
    }

    public void Stop() {
        IsActive = false;
        CurrentTime = 0;
    }

    public float StartTime => initTime;
}
