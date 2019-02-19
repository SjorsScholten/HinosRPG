using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleTimer))]
[RequireComponent(typeof(CapsuleCollider))]
public class SpawnPickUp : MonoBehaviour {

    [SerializeField]
    private SimpleItem item;
    
    private ITimer timer;

    private void Awake() {
        timer = GetComponent<ITimer>();
        timer.OnTimerElapse += OnElapse;
        timer.Initialize();
    }

    private void OnTriggerEnter(Collider other) {
        if (timer.IsActive) return;
        
        var inventory = other.GetComponentInParent<IInventory>();
        if (inventory == null) return;
        inventory.AddItem(item);
        active(false);
        timer.Initialize();
    }

    private void OnElapse(object source, EventArgs args) {
        active(true);
    }

    private void active(bool value) {
        var t = GetComponentInChildren<Transform>();
        foreach (Transform tr in t) {
            if(tr.Equals(transform)) continue;
            tr.gameObject.SetActive(value);
        }
    }
    
}
