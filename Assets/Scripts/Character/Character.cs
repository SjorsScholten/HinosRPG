using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter {
    
    [Header("Movement")]
    
    [SerializeField]
    [Tooltip("Walk speed in m/s")]
    private float walkSpeed = 5f;

    [SerializeField]
    [Tooltip("Run speed in m/s")]
    private float runSpeed = 10f;


    [Header("Interaction")]
    
    [SerializeField]
    private float interactionRange = 1.5f;

    private IInput inputComponent;
    private ICharacterMovement characterMovement;

    private void Awake() {
        inputComponent = GetComponentInParent<IInput>();
        inputComponent.Interacting += OnInteract;
        characterMovement = GetComponent<ICharacterMovement>();
    }

    private void FixedUpdate() {
        var speed = inputComponent.IsRunning ? runSpeed : walkSpeed;
        var direction = inputComponent.MovementDirection;
        if (direction != Vector3.zero) {
            characterMovement.Move(direction, speed);
        }
    }
    
    private void OnInteract(object sender, EventArgs e) {
        var objectsInRange = Physics.OverlapSphere(transform.position, interactionRange);
        foreach (Collider o in objectsInRange) {
            var interactable = o.gameObject.GetComponentInParent<IInteractable>();
            interactable?.Interact();
        }
    }
}
