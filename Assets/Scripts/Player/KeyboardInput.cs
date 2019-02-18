using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInput {
    
    public event EventHandler Interacting;

    private void Update() {
        if (Input.GetButtonDown("Interaction")) {
            OnInteract();
        }
    }

    private void OnInteract() {
        Interacting?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 MovementDirection {
        get {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            return new Vector3(horizontal, 0, vertical);
        }
    }

    public bool IsRunning => Input.GetButton("Running");
}
