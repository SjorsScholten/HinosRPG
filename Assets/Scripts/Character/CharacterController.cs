using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacter {
    
    [Header("Movement")]
    
    [SerializeField]
    [Tooltip("Walk speed in m/s")]
    private float walkSpeed = 5f;

    [SerializeField]
    [Tooltip("Run speed in m/s")]
    private float runSpeed = 10f;

    private IInput inputComponent;
    private ICharacterMovement characterMovement;

    private void Awake() {
        inputComponent = GetComponentInParent<IInput>();
        characterMovement = GetComponent<ICharacterMovement>();
    }

    private void FixedUpdate() {
        var speed = inputComponent.IsRunning ? runSpeed : walkSpeed;
        var direction = inputComponent.MovementDirection;
        if (direction != Vector3.zero) {
            characterMovement.Move(direction, speed);
        }
    }
}
